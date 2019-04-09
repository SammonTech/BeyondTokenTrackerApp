// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { PermissionValues } from './permission.model';


export interface LoginResponse {
    access_token: string;
    refresh_token: string;
    expires_in: number;
    token_type: string;
}


export interface IAccessToken {
    nbf: number;
    exp: number;
    iss: string;
    aud: string | string[];
    client_id: string;
    sub: string;
    auth_time: number;
    idp: string;
    roleId: number;
    name: string;
    email: string;
    userId: number;
    groupId: number;
    password: string;
    amr: string[];
}

export class AccessToken {
  constructor(name: string, email: string, userId: number, groupId: number, roleId: number) {
    this.nbf = 0;
    this.exp = 999999999;
    this.iss = '';
    this.aud = '';
    this.client_id = '';
    this.sub = '';
    this.auth_time = 9999999;
    this.idp = '';
    this.roleId = roleId;
    this.name = name;
    this.email= email;
    this.userId = userId;
    this.groupId = groupId;
    this.password = '';
    this.amr = [];
  }
  public nbf: number;
  public exp: number;
  public iss: string;
  public aud: string | string[];
  public client_id: string;
  public sub: string;
  public auth_time: number;
  public idp: string;
  public roleId: number;
  public name: string;
  public email: string;
  public userId: number;
  public groupId: number;
  public password: string;
  public amr: string[];
}
