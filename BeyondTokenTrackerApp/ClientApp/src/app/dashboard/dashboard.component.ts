import { Component, OnInit } from '@angular/core';
import { Observable, Subject, throwError } from 'rxjs';

import { AuthService } from '../authentication/auth.service';
import { TokenService } from '../services/token.service';

import { Transaction } from '../models/transaction.model';
import { TokenStats } from '../models/token-stats.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  tokenStats: TokenStats = new TokenStats();

  transactions: Transaction[];
  displayHistory: boolean = false;

  constructor(private authService: AuthService, private tokenService: TokenService) { }

  ngOnInit() {
    // get token type for giving token for this user
    this.tokenService.getTransactionsStats(this.currentUser.userId, this.currentUser.roleId).subscribe(x => {
      this.tokenStats = x;
    });

  }

  get currentUser() {
    return this.authService.currentUser;
  }

  showHistory() {
    this.displayHistory = false;
    this.tokenService.getTransactionsForUser(this.currentUser.userId).subscribe(x => {
      this.transactions = x;
      this.displayHistory = true;
    });
  }

  hideHistory() {
    this.displayHistory = false;
  }
}
