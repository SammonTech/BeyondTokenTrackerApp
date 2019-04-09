import { User } from './user.model';
import { Product } from './product.model';

export class Transaction {
  public pointTransactionId: number;
  public pointTransactionTypeId: number;
  public transactionDate: Date;
  public productId: number;
  public points: number;
  public awardToId: number;
  public awardFromId: number;
  public awardMessage: string;
  public awardTo: User;
  public awardFrom: User;
  public product: Product;
}
