import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { EndpointFactory } from './endpoint-factory.service';
import { ConfigurationService } from './configuration.service';


@Injectable()
export class UserEndpoint extends EndpointFactory {

  private readonly _usersAllUrl: string = '/api/users/all';
  private readonly _userByIdUrl: string = '/api/users';

  get usersAllUrl() { return this.configurations.baseUrl + this._usersAllUrl; }
  get userByIdUrl() { return this.configurations.baseUrl + this._userByIdUrl; }



  constructor(http: HttpClient, configurations: ConfigurationService, injector: Injector) {
    super(http, configurations, injector);
  }
  
  getUserByIdEndpoint<T>(userId: string): Observable<T> {
    const endpointUrl = `${this.userByIdUrl}/${userId}`;

    return this.http.get<T>(endpointUrl);
  }


  getUsersEndpoint<T>(): Observable<T> {
    const endpointUrl = this.usersAllUrl;

    return this.http.get<T>(endpointUrl);
  }
  /*
  getNewUserEndpoint<T>(userObject: any): Observable<T> {

    return this.http.post<T>(this.usersUrl, JSON.stringify(userObject), this.getRequestHeaders()).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getNewUserEndpoint(userObject));
      }));
  }

  getUpdateUserEndpoint<T>(userObject: any, userId?: string): Observable<T> {
    const endpointUrl = userId ? `${this.usersUrl}/${userId}` : this.currentUserUrl;

    return this.http.put<T>(endpointUrl, JSON.stringify(userObject), this.getRequestHeaders()).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getUpdateUserEndpoint(userObject, userId));
      }));
  }
  */
  
}
