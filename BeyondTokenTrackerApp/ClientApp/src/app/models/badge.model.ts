export class Badge {
  constructor(
    badgeId?: number,
    groupId?: number,
    name?: string,
    tokensRequired?: number,
    imgSrc?: string) {
    this.badgeId = badgeId;
    this.groupId = groupId;
    this.name = name;
    this.tokensRequired = tokensRequired;
    this.imgSrc = imgSrc;
  }

  public badgeId: number;
  public groupId: number;
  public name: string;
  public tokensRequired: number;
  public imgSrc: string;
}
