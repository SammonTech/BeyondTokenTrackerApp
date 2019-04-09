import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthService } from './authentication/auth.service';
import { AuthGuard } from './authentication/auth-guard.service';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserComponent } from './user/user.component';
import { AddTransactionComponent } from './add-transaction/add-transaction.component';
import { NotFoundComponent } from './not-found/not-found.component';


const routes: Routes = [
  { path: '', component: DashboardComponent, canActivate: [AuthGuard], data: { title: 'Dashboard' } },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard], data: { title: 'Dashboard' } },
  { path: 'login', component: LoginComponent, data: { title: 'Login' } },
  { path: 'users', component: UserComponent, canActivate: [AuthGuard], data: { title: 'Users' } },
  { path: 'give-tokens', component: AddTransactionComponent, canActivate: [AuthGuard], data: { title: 'Give Tokens' } },
  { path: '**', component: NotFoundComponent, data: { title: 'Page Not Found' } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [
    AuthService,
    AuthGuard]
})
export class AppRoutingModule { }
