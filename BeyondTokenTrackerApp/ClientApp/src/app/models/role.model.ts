export class Role {
  constructor(
    roleId?: number,
    name?: string) {

    this.roleId = roleId;
    this.name = name;
  }

  public roleId: number;
  public name: string;
}
