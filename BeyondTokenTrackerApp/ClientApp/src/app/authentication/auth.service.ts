import { Injectable } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { map } from 'rxjs/operators';

import { ConfigurationService } from '../services/configuration.service';
import { LocalStoreManager } from '../services/local-store-manager.service';
import { AccessToken } from '../models/login-response.model';
import { JwtHelper } from '../services/jwt-helper';
import { DBkeys } from '../services/db-keys';
import { EndpointFactory } from '../services/endpoint-factory.service';
import { User, IUser } from '../models/user.model';
import { Utilities } from '../services/utilities';

import { roles, groups } from '../models/enums';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public get loginUrl() { return this.configurations.loginUrl; }

  public loginRedirectUrl: string;
  public logoutRedirectUrl: string;

  public reLoginDelegate: () => void;

  private previousIsLoggedInCheck = false;
  private _loginStatus = new Subject<boolean>();

  constructor(private router: Router, private configurations: ConfigurationService, private endpointFactory: EndpointFactory, private localStorage: LocalStoreManager) {
    this.initializeLoginStatus();
  }

  private initializeLoginStatus() {
    this.localStorage.getInitEvent().subscribe(() => {
      this.reevaluateLoginStatus();
    });
  }

  gotoPage(page: string, preserveParams = true) {

    const navigationExtras: NavigationExtras = {
      queryParamsHandling: preserveParams ? 'merge' : '', preserveFragment: preserveParams
    };

    this.router.navigate([page], navigationExtras);
  }

  gotoHomePage() {
    this.router.navigate([this.configurations.homeUrl]);
  }

  redirectLoginUser() {
    const redirect = this.loginRedirectUrl && this.loginRedirectUrl != '/' && this.loginRedirectUrl != ConfigurationService.defaultHomeUrl ? this.loginRedirectUrl : this.configurations.homeUrl;
    this.loginRedirectUrl = null;

    const urlParamsAndFragment = Utilities.splitInTwo(redirect, '#');
    const urlAndParams = Utilities.splitInTwo(urlParamsAndFragment.firstPart, '?');

    const navigationExtras: NavigationExtras = {
      fragment: urlParamsAndFragment.secondPart,
      queryParams: Utilities.getQueryParamsFromString(urlAndParams.secondPart),
      queryParamsHandling: 'merge'
    };

    this.router.navigate([urlAndParams.firstPart], navigationExtras);
  }

  redirectLogoutUser() {
    const redirect = this.logoutRedirectUrl ? this.logoutRedirectUrl : this.loginUrl;
    this.logoutRedirectUrl = null;

    this.router.navigate([redirect]);
  }

  redirectForLogin() {
    this.loginRedirectUrl = this.router.url;
    this.router.navigate([this.configurations.loginUrl]);
  }

  reLogin() {
    this.localStorage.deleteData(DBkeys.TOKEN_EXPIRES_IN);

    if (this.reLoginDelegate) {
      this.reLoginDelegate();
    } else {
      this.redirectForLogin();
    }
  }

  login(userName: string, password: string, rememberMe?: boolean) {

    if (this.isLoggedIn) {
      this.logout();
    }

    return this.endpointFactory.getLoginEndpoint<IUser>(userName, password).pipe(
      map(response => this.processLoginResponse(response, rememberMe)));
  }


  private processLoginResponse(response: IUser, rememberMe: boolean) {

    if (response == null) {
      throw new Error('Received unauthorizaed');

    }

    const accessToken = new AccessToken(response.name, response.email, response.userId, response.groupId, response.roleId); //response.access_token;

    const refreshToken = '';
    const expiresIn = 86400000;

    const tokenExpiryDate = new Date();
    tokenExpiryDate.setSeconds(tokenExpiryDate.getSeconds() + expiresIn);

    const accessTokenExpiry = tokenExpiryDate;

   // const jwtHelper = new JwtHelper();
    //const decodedAccessToken = <AccessToken>jwtHelper.urlBase64Decode(accessToken);

    const user = new User(
      accessToken.userId,
      accessToken.groupId,
      accessToken.roleId,
      accessToken.name,
      accessToken.email,
      accessToken.password);

    this.saveUserDetails(user, 'access_token', refreshToken, accessTokenExpiry, rememberMe);

    this.reevaluateLoginStatus(user);

    return user;
  }

  private saveUserDetails(user: User, accessToken: string, refreshToken: string, expiresIn: Date, rememberMe: boolean) {
    if (rememberMe) {
      this.localStorage.savePermanentData(accessToken, DBkeys.ACCESS_TOKEN);
      this.localStorage.savePermanentData(refreshToken, DBkeys.REFRESH_TOKEN);
      this.localStorage.savePermanentData(expiresIn, DBkeys.TOKEN_EXPIRES_IN);
      this.localStorage.savePermanentData(user, DBkeys.CURRENT_USER);
    } else {
      this.localStorage.saveSyncedSessionData(accessToken, DBkeys.ACCESS_TOKEN);
      this.localStorage.saveSyncedSessionData(refreshToken, DBkeys.REFRESH_TOKEN);
      this.localStorage.saveSyncedSessionData(expiresIn, DBkeys.TOKEN_EXPIRES_IN);
      this.localStorage.saveSyncedSessionData(user, DBkeys.CURRENT_USER);
    }
    
    this.localStorage.savePermanentData(rememberMe, DBkeys.REMEMBER_ME);
  }

  logout(): void {
    this.localStorage.deleteData(DBkeys.ACCESS_TOKEN);
    this.localStorage.deleteData(DBkeys.REFRESH_TOKEN);
    this.localStorage.deleteData(DBkeys.TOKEN_EXPIRES_IN);
    this.localStorage.deleteData(DBkeys.USER_PERMISSIONS);
    this.localStorage.deleteData(DBkeys.CURRENT_USER);

    this.configurations.clearLocalChanges();

    this.reevaluateLoginStatus();
  }

  private reevaluateLoginStatus(currentUser?: User) {
    const user = currentUser || this.localStorage.getDataObject<User>(DBkeys.CURRENT_USER);
    //console.log(user);
    const isLoggedIn = user != null;
    //console.log('isLoggedIn = ' + isLoggedIn);

    if (this.previousIsLoggedInCheck != isLoggedIn) {
      setTimeout(() => {
        this._loginStatus.next(isLoggedIn);
      });
    }

    this.previousIsLoggedInCheck = isLoggedIn;
  }

  getLoginStatusEvent(): Observable<boolean> {
    return this._loginStatus.asObservable();
  }

  get currentUser(): User {

    const user = this.localStorage.getDataObject<User>(DBkeys.CURRENT_USER);
    this.reevaluateLoginStatus(user);

    return user;
  }

  get accessToken(): string {

    this.reevaluateLoginStatus();
    return this.localStorage.getData(DBkeys.ACCESS_TOKEN);
  }

  get accessTokenExpiryDate(): Date {

    this.reevaluateLoginStatus();
    return this.localStorage.getDataObject<Date>(DBkeys.TOKEN_EXPIRES_IN, true);
  }

  get isSessionExpired(): boolean {
    if (this.accessTokenExpiryDate == null) {
      return true;
    }

    return this.accessTokenExpiryDate.valueOf() <= new Date().valueOf();
  }

  get refreshToken(): string {

    this.reevaluateLoginStatus();
    return this.localStorage.getData(DBkeys.REFRESH_TOKEN);
  }

  get isLoggedIn(): boolean {
    return this.currentUser != null;
  }

  get rememberMe(): boolean {
    return this.localStorage.getDataObject<boolean>(DBkeys.REMEMBER_ME) == true;
  }

  get isAdmin(): boolean {
    return this.currentUser.roleId == <number>roles.Admin;
  }
}
