import { User } from './user.model';
import { Badge } from './badge.model';

export class Group {
  constructor(
    groupId?: number,
    name?: string) {
    this.groupId = groupId;
    this.name = name;
  }

  public groupId: number;
  public name: string;
  public groupDetails: GroupDetail[];
  public users: User[];
  public badges: Badge[];
}

export class GroupDetail {
  constructor(
    groupDetailId?: number,
    groupId?: number,
    name?: string,
    valueNumber?: number,
    valueString?: string,
    valueDate?: Date) {
    this.groupId = groupId;
    this.name = name;
    this.valueNumber = valueNumber;
    this.valueString = valueString;
    this.valueDate = valueDate;
  }

  public groupId: number;
  public name: string;
  public valueNumber: number;
  public valueString: string;
  public valueDate: Date;
}
