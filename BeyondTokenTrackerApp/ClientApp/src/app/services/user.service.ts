import { Injectable } from '@angular/core';

import { UserEndpoint } from './user-endpoint.service';
import { AuthService } from '../authentication/auth.service';
import { User } from '../models/user.model';

@Injectable()
export class UserService {
 
  constructor(
    private authService: AuthService,
    private userEndpoint: UserEndpoint) {

  }

  getUser(userId: string) {
    return this.userEndpoint.getUserByIdEndpoint<User>(userId);
  }

  getAllUser() {
    return this.userEndpoint.getUsersEndpoint<User[]>();
  }

  getActiveUser() {
    return this.userEndpoint.getActiveUsersEndpoint<User[]>();
  }
  //updateUser(user: UserEdit) {
  //  return this.userEndpoint.getUpdateUserEndpoint(user, user.userId);
  //}

  //newUser(user: UserEdit) {
  //  return this.userEndpoint.getNewUserEndpoint<User>(user);
  //}
  
  //refreshLoggedInUser() {
  //  return this.authService.refreshLogin();
  //}

  get currentUser() {
    return this.authService.currentUser;
  }
}

