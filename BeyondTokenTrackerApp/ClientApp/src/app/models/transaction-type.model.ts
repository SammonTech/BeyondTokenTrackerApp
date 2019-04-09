import { Role } from './role.model';

export class TransactionType {
  constructor(
    pointTransactionTypeId?: number,
    roleId?: number,
    name?: string,
    affectOnAwardTo?: number,
    affectOnAwardFrom?: number,
    isActive?: boolean) {
    
    this.pointTransactionTypeId = pointTransactionTypeId;
    this.roleId = roleId;
    this.name = name;
    this.affectOnAwardTo = affectOnAwardTo;
    this.affectOnAwardFrom = affectOnAwardFrom;
    this.isActive = isActive;
  }

  public pointTransactionTypeId: number;
  public roleId: number;
  public name: string;
  public affectOnAwardTo: number;
  public affectOnAwardFrom: number;
  public isActive: boolean;

  public role: Role;
}
