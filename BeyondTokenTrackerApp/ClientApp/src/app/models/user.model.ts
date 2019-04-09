import { Transaction } from './transaction.model';

export class User {
  constructor(userId?: number,
    groupId?: number,
    roleId?: number,
    name?: string,
    email?: string,
    password?: string,
    imgSrc?: string) {

    this.userId = userId;
    this.groupId = groupId;
    this.roleId = roleId;
    this.name = name;
    this.email = email;
    this.password = password;
    this.imgSrc = imgSrc;
  }

  public userId: number;
  public groupId: number;
  public roleId: number;
  public name: string;
  public email: string;
  public password: string;
  public imgSrc: string;

  public pointTransactionAwardFrom: Transaction[];
  public pointTransactionAwardTo: Transaction[];
}

export interface IUser {
  userId: number;
  groupId: number;
  roleId: number;
  name: string;
  email: string;
  password: string;
  imgSrc: string;
  pointTransactionAwardFrom: Transaction[];
  pointTransactionAwardTo: Transaction[];
}
