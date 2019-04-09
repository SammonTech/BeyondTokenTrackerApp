import { Injectable } from '@angular/core';
import { LocalStoreManager } from './local-store-manager.service';
import { DBkeys } from './db-keys';
import { environment } from '../../environments/environment';
import { Utilities } from './utilities';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {
  public baseUrl = Utilities.baseUrl() || 'https://localhost:44301/';
  public static readonly defaultHomeUrl: string = '/';
  public homeUrl: string = '/';
  public loginUrl: string = '/login';
  public loginApiUrl: string = 'api/users/login';
  public userApiUrl: string = 'api/users';
  public transactionApiUrl: string = 'api/transaction';
  public transactionTypeApiUrl: string = 'api/tokentype';

  constructor(private localStorage: LocalStoreManager) {

  }

  public clearLocalChanges() {
    
  }

}
