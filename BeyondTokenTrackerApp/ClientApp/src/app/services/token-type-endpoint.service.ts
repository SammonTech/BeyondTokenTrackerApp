import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { EndpointFactory } from './endpoint-factory.service';
import { ConfigurationService } from './configuration.service';

@Injectable()
export class TokenTypeEndpoint extends EndpointFactory {

  private readonly _tokenTypeByTypeIdUrl: string = '/api/tokentype/id';
  private readonly _tokenTypeAllUrl: string = '/api/tokentype/all';
  private readonly _tokenTypeByRoleUrl: string = '/api/tokentype/role';

  get tokenTypeByTypeIdUrl() { return this.configurations.baseUrl + this._tokenTypeByTypeIdUrl; }
  get tokenTypeByRoleUrl() { return this.configurations.baseUrl + this._tokenTypeByRoleUrl; }
  get tokenTypeAllUrl() { return this.configurations.baseUrl + this._tokenTypeAllUrl; }

  constructor(http: HttpClient, configurations: ConfigurationService, injector: Injector) {
    super(http, configurations, injector);
  }

  geTransactionTypeByTypeIdIdEndpoint<T>(id: number): Observable<T> {
    const endpointUrl = `${this.tokenTypeByTypeIdUrl}?id=${id}`;
    console.log('geTransactionTypesByTypeIdIdEndpoint = ' + endpointUrl);

    return this.http.get<T>(endpointUrl, this.getRequestHeaders()).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.geTransactionTypeByTypeIdIdEndpoint(id));
      }));
  }

  geTransactionTypesByRoleIdIdEndpoint<T>(roleId: number): Observable<T> {
    const endpointUrl = `${this.tokenTypeByRoleUrl}?roleId=${roleId}`;
    console.log('geTransactionTypesByRoleIdIdEndpoint = ' + endpointUrl);

    return this.http.get<T>(endpointUrl, this.getRequestHeaders()).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.geTransactionTypesByRoleIdIdEndpoint(roleId));
      }));
  }


  getTransactionsAllEndpoint<T>(): Observable<T> {
    const endpointUrl = this.tokenTypeAllUrl;

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
