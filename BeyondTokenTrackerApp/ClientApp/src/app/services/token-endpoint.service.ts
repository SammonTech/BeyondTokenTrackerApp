import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { EndpointFactory } from './endpoint-factory.service';
import { ConfigurationService } from './configuration.service';


@Injectable()
export class TokenEndpoint extends EndpointFactory {

  private readonly _tokenAllUrl: string = '/api/token/all';
  private readonly _tokenByUserIdUrl: string = '/api/token/usertxn';
  private readonly _tokenStatsUrl: string = '/api/token/stats';
  private readonly _tokenInsertUrl: string = '/api/token/insert';

  get tokenAllUrl() { return this.configurations.baseUrl + this._tokenAllUrl; }
  get tokenByUserIdUrl() { return this.configurations.baseUrl + this._tokenByUserIdUrl; }
  get tokenStatsUrl() { return this.configurations.baseUrl + this._tokenStatsUrl; }
  get tokenInsertUrl() { return this.configurations.baseUrl + this._tokenInsertUrl; }



  constructor(http: HttpClient, configurations: ConfigurationService, injector: Injector) {
    super(http, configurations, injector);
  }

  getTransactionsByUserIdIdEndpoint<T>(userId: number): Observable<T> {
    const endpointUrl = `${this.tokenByUserIdUrl}?userId=${userId}`;

    return this.http.get<T>(endpointUrl, this.getRequestHeaders()).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getTransactionsByUserIdIdEndpoint(userId));
      }));
  }

  getTransactionsAllEndpoint<T>(): Observable<T> {
    const endpointUrl = this.tokenAllUrl;

    return this.http.get<T>(endpointUrl);
  }

  getTransactionsStatsEndpoint<T>(userId: number, roleId: number): Observable<T> {
    const endpointUrl = `${this.tokenStatsUrl}?userId=${userId}&roleId=${roleId}`;

    return this.http.get<T>(endpointUrl, this.getRequestHeaders()).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getTransactionsStatsEndpoint(userId, roleId));
      }));
  }

  insertTokenEndpoint<T>(object: any): Observable<T> {
    return this.http.post<T>(this.tokenInsertUrl, JSON.stringify(object), this.getRequestHeaders()).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.insertTokenEndpoint(object));
      }));
  }

  /*
  getUpdateUserEndpoint<T>(userObject: any, userId?: string): Observable<T> {
    const endpointUrl = userId ? `${this.usersUrl}/${userId}` : this.currentUserUrl;

    return this.http.put<T>(endpointUrl, JSON.stringify(userObject), this.getRequestHeaders()).pipe<T>(
      catchError(error => {
        return this.handleError(error, () => this.getUpdateUserEndpoint(userObject, userId));
      }));
  }
  */

}
