import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, Subject, throwError } from 'rxjs';
import { mergeMap, switchMap, catchError } from 'rxjs/operators';

import { AuthService } from '../authentication/auth.service';
import { ConfigurationService } from './configuration.service';

@Injectable({
  providedIn: 'root'
})
export class EndpointFactory {
  static readonly apiVersion: string = '1';

  //private readonly _loginUrl: string = '/connect/token';

  private get loginUrl() {
    return 'https://localhost:44301/api/users/login';
  } //this.configurations.baseUrl + this.configurations.loginUrl; }

  //private taskPauser: Subject<any>;
  private isRefreshingLogin: boolean;

  private _authService: AuthService;

  private get authService() {
    if (!this._authService) {
      this._authService = this.injector.get(AuthService);
    }

    return this._authService;
  }

  constructor(protected http: HttpClient, protected configurations: ConfigurationService, private injector: Injector) { }

  getLoginEndpoint<T>(userName: string, password: string): Observable<T> {

    const header = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });

    const params = new HttpParams()
      .append('email', userName)
      .append('password', password);

    return this.http.get<T>(this.loginUrl, { headers: header, params: params });
  }

  //getRefreshLoginEndpoint<T>(): Observable<T> {
  //  const header = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });

  //  const params = new HttpParams()
  //    .append('refresh_token', this.authService.refreshToken)
  //    .append('client_id', 'quickapp_spa')
  //    .append('grant_type', 'refresh_token');

  //  return this.http.post<T>(this.loginUrl, params, { headers: header }).pipe<T>(
  //    catchError(error => {
  //      return this.handleError(error, () => this.getRefreshLoginEndpoint());
  //    }));
  //}

  protected getRequestHeaders(): { headers: HttpHeaders | { [header: string]: string | string[]; } } {
    const headers = new HttpHeaders({
      // 'Authorization': 'Bearer ' + this.authService.accessToken,
      'Content-Type': 'application/json',
      'Accept': 'application/json, text/plain, */*'
    });

    return { headers: headers };
  }

  protected handleError(error, continuation: () => Observable<any>) {
    console.log('handleError err = ' + error.status);
    if (error.status == 401) {
      if (this.isRefreshingLogin) {
        return throwError(error); //this.pauseTask(continuation);
      }

      //this.isRefreshingLogin = true;

      //return this.authService.refreshLogin().pipe(
      //  mergeMap(data => {
      //    this.isRefreshingLogin = false;
      //    this.resumeTasks(true);

      //    return continuation();
      //  }),
      //  catchError(refreshLoginError => {
      //    this.isRefreshingLogin = false;
      //    this.resumeTasks(false);

      //    if (refreshLoginError.status == 401 || (refreshLoginError.url && refreshLoginError.url.toLowerCase().includes(this.loginUrl.toLowerCase()))) {
      //      this.authService.reLogin();
      //      return throwError('session expired');
      //    } else {
      //      return throwError(refreshLoginError || 'server error');
      //    }
      //  }));
    }

    // if (error.url && error.url.toLowerCase().includes(this.loginUrl.toLowerCase())) {
    //   this.authService.reLogin();

    //   return throwError((error.error && error.error.error_description) ? `session expired (${error.error.error_description})` : 'session expired');
    //  } else {
    return throwError(error);
    // }
  }

  //private pauseTask(continuation: () => Observable<any>) {
  //  if (!this.taskPauser) {
  //    this.taskPauser = new Subject();
  //  }

  //  return this.taskPauser.pipe(switchMap(continueOp => {
  //    return continueOp ? continuation() : throwError('session expired');
  //  }));
  //}

  //private resumeTasks(continueOp: boolean) {
  //  setTimeout(() => {
  //    if (this.taskPauser) {
  //      this.taskPauser.next(continueOp);
  //      this.taskPauser.complete();
  //      this.taskPauser = null;
  //    }
  //  });
  //}
}
