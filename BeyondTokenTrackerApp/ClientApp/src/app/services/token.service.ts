/// <reference path="../models/token-stats.model.ts" />
import { Injectable } from '@angular/core';

import { AuthService } from '../authentication/auth.service';
import { TokenEndpoint } from './token-endpoint.service';
import { Transaction } from '../models/transaction.model';
import { TokenStats } from '../models/token-stats.model';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor(
    private authService: AuthService,
    private tokenEndpoint: TokenEndpoint) {

  }

  getTransactionsForUser(userId: number) {
    console.log('getTransactionsForUser fired');
    return this.tokenEndpoint.getTransactionsByUserIdIdEndpoint<Transaction[]>(userId);
  }

  getTransactionsStats(userId: number, roleId: number) {
    console.log('getTransactionsStatsEndpoint fired');
    return this.tokenEndpoint.getTransactionsStatsEndpoint<TokenStats>(userId, roleId);
  }

  insertToken(object: Transaction) {
    return this.tokenEndpoint.insertTokenEndpoint(object);
  }
}
