import { Injectable } from '@angular/core';

import { AuthService } from '../authentication/auth.service';
import { TokenTypeEndpoint } from './token-type-endpoint.service';
import { TransactionType } from '../models/transaction-type.model';

@Injectable({
  providedIn: 'root'
})
export class TokenTypeService {

  constructor(
    private authService: AuthService,
    private tokenTypeEndpoint: TokenTypeEndpoint) {

  }

  getTransactionTypeByTypeId(tokenTypeId: number) {
    console.log('getTransactionsForUser fired');
    return this.tokenTypeEndpoint.geTransactionTypeByTypeIdIdEndpoint<TransactionType[]>(tokenTypeId);
  }
}
