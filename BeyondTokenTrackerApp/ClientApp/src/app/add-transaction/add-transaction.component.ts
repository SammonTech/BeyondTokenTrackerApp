import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
//import { ToastaService, ToastaConfig, ToastOptions, ToastData } from 'ngx-toasta';
import { AlertService, AlertCommand, MessageSeverity } from '../services/alert.service';

import { ProductTypes, TokenTypes } from '../models/enums';
import { Transaction } from '../models/transaction.model';
//import { TransactionType } from '../models/transaction-type.model';
import { TokenStats } from '../models/token-stats.model';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { AuthService } from '../authentication/auth.service';
import { TokenService } from '../services/token.service';
import { TokenTypeService } from '../services/token-type.service';

@Component({
  selector: 'app-add-transaction',
  templateUrl: './add-transaction.component.html',
  styleUrls: ['./add-transaction.component.scss']
})
export class AddTransactionComponent implements OnInit {
  //stickyToasties: number[] = [];
  public currentUser: User;
 // public totalTokensAwarded: string;
 // public awardsBankBalance: number;
 // public giveBankBalance: number;

  public tokenAwardAmount: number;
  public awardReason: string;
  public awardToUser: number;

  public users: User[];
 // public transaction = new Transaction();
 // public txnGivenThisMonth: Transaction[];
  public tokenStats: TokenStats = new TokenStats();

 // public transTypeAllowed = new TransactionType();


  constructor(private authService: AuthService, private httpClient: HttpClient, private tokenService: TokenService, private tokenTypeService: TokenTypeService,
   // private toastaService: ToastaService,
   // private toastaConfig: ToastaConfig,
    private userService: UserService,
    private alertService: AlertService) { }

  ngOnInit() {
    this.alertService.resetStickyMessage();
    this.currentUser = this.authService.currentUser;

    // get token type for giving token for this user
    this.tokenService.getTransactionsStats(this.currentUser.userId, this.currentUser.roleId).subscribe(x => {
      this.tokenStats = x;
    });

    //this.getAllUsers().subscribe(x => {
    this.userService.getActiveUser().subscribe(x => {
      this.users = x.sort(function (a, b) {
        var x = a.name.toLowerCase();
        var y = b.name.toLowerCase();
        if (x < y) { return -1; }
        if (x > y) { return 1; }
        return 0;
      });
      const index = this.users.findIndex(user => user.userId === this.currentUser.userId);
      if (index > -1) {
        this.users.splice(index, 1);
      }
      
    });

  }

  submit() {
    let t: Transaction = new Transaction();
    t.awardFromId = this.currentUser.userId;
    t.awardMessage = this.awardReason ? this.awardReason : "";
    t.awardToId = this.awardToUser;
    t.points = this.tokenAwardAmount;
    t.productId = ProductTypes.Kudos;
    t.transactionDate = new Date();
    t.pointTransactionTypeId = TokenTypes.KudosGiveUser;

    if (t.points > this.tokenStats.amtAvailToGivePeriod) {
      return;
    }
    
    this.postTransaction(t).subscribe(x => {
      let user: User = this.users.filter(u => u.userId == t.awardToId)[0];
      this.alertService.resetStickyMessage();
      this.alertService.showMessage("You've awarded " + t.points + " tokens to " + user.name, '', MessageSeverity.default);

      this.tokenService.getTransactionsStats(this.currentUser.userId, this.currentUser.roleId).subscribe(x => {
        console.log('getTransactionsStats fired');
          this.tokenStats = x;
          this.tokenAwardAmount = 0;
          this.awardToUser = null;
          this.awardReason = '';
        });
    });
  }

  //getUser(): Observable<User> {
  //  return this.httpClient.get<User>('api/user?userid='+this.currentUser.userId)
  //    .pipe(map(res => res));
  //}

  //getAllUsers(): Observable<User[]> {
  //  return this.httpClient.get<User[]>('api/users/all')
  //    .pipe(map(res => res));
  //}

  postTransaction(submission: Transaction) {
    return this.tokenService.insertToken(submission)
      .pipe(map(res => res));
  }
  
}
