export class Configuration {
  constructor(
    configurationId?: number,
    name?: string,
    valueNumber?: number,
    valueString?: string,
    valueDate?: Date) {
    this.configurationId = configurationId;
    this.name = name;
    this.valueNumber = valueNumber;
    this.valueString = valueString;
    this.valueDate = valueDate;
  }

  public configurationId: number;
  public name: string;
  public valueNumber: number;
  public valueString: string;
  public valueDate: Date;
}
