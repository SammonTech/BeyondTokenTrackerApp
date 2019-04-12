import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

//import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ToastaModule } from 'ngx-toasta';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CarouselModule } from 'ngx-bootstrap/carousel';
//import { ChartsModule } from 'ng2-charts';

import { EqualValidator } from './directives/equal-validator.directive';
import { LastElementDirective } from './directives/last-element.directive';
import { AutofocusDirective } from './directives/autofocus.directive';
import { BootstrapTabDirective } from './directives/bootstrap-tab.directive';
import { BootstrapToggleDirective } from './directives/bootstrap-toggle.directive';
import { BootstrapSelectDirective } from './directives/bootstrap-select.directive';
import { BootstrapDatepickerDirective } from './directives/bootstrap-datepicker.directive';
import { GroupByPipe } from './pipes/group-by.pipe';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { AddTransactionComponent } from './add-transaction/add-transaction.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ProductListComponent } from './product-list/product-list.component';
import { RedeemTokensComponent } from './redeem-tokens/redeem-tokens.component';

//services
import { AlertService } from './services/alert.service';
import { Utilities } from './services/utilities';
import { LocalStoreManager } from './services/local-store-manager.service';
import { ConfigurationService } from './services/configuration.service';
import { EndpointFactory } from './services/endpoint-factory.service';
import { UserService } from './services/user.service';
import { UserEndpoint } from './services/user-endpoint.service';
import { TokenEndpoint } from './services/token-endpoint.service';
import { TokenTypeEndpoint } from './services/token-type-endpoint.service';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserComponent,
   // NotificationsViewerComponent,
    EqualValidator,
    LastElementDirective,
    AutofocusDirective,
    BootstrapTabDirective,
    BootstrapToggleDirective,
    BootstrapSelectDirective,
    BootstrapDatepickerDirective,
    GroupByPipe,
    AddTransactionComponent,
    DashboardComponent,
    NotFoundComponent,
    ProductListComponent,
    RedeemTokensComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ToastaModule.forRoot(),
    TooltipModule.forRoot(),
    PopoverModule.forRoot(),
    BsDropdownModule.forRoot(),
    CarouselModule.forRoot(),
    ModalModule.forRoot()
   // , gxDatatableModule
   // , ChartsModule
  ],
  providers: [
    AlertService,
    Utilities,
    LocalStoreManager,
    ConfigurationService,
    EndpointFactory,
    UserService,
    UserEndpoint,
    TokenEndpoint,
    TokenTypeEndpoint
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
