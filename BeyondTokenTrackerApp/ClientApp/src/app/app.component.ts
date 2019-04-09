import { Component, ViewEncapsulation, OnInit, OnDestroy, ViewChildren, AfterViewInit, QueryList, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { ToastaService, ToastaConfig, ToastOptions, ToastData } from 'ngx-toasta';
import { ModalDirective } from 'ngx-bootstrap/modal';

import { AlertService, AlertDialog, DialogType, AlertCommand, AlertMessage, MessageSeverity } from './services/alert.service';
//import { NotificationService } from './services/notification.service';
import { UserService } from './services/user.service';
import { LocalStoreManager } from './services/local-store-manager.service';
import { AuthService } from './authentication/auth.service';
import { ConfigurationService } from './services/configuration.service';
import { LoginComponent } from './login/login.component';

declare var require: any;
const alertify: any = require('./assets/scripts/alertify.js');

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, AfterViewInit {

  isAppLoaded: boolean;
  isUserLoggedIn: boolean;
  shouldShowLoginModal: boolean;
  removePrebootScreen: boolean;
  newNotificationCount = 0;
  appTitle = 'Beyond Token Tracker App';
  //appLogo = require('../assets/images/logo-white.png');

  stickyToasties: number[] = [];

  dataLoadingConsecutiveFailures = 0;
  notificationsLoadingSubscription: any;

  @ViewChildren('loginModal,loginControl')
  modalLoginControls: QueryList<any>;

  loginModal: ModalDirective;
  loginControl: LoginComponent;

  constructor(
    storageManager: LocalStoreManager,
    private toastaService: ToastaService,
    private toastaConfig: ToastaConfig,
   // private accountService: UserService,
    private alertService: AlertService,
  //  private notificationService: NotificationService,
    private authService: AuthService,
    public configurations: ConfigurationService,
    public router: Router) {
    console.log('constructor fired');
    storageManager.initialiseStorageSyncListener();

    this.toastaConfig.theme = 'bootstrap';
    this.toastaConfig.position = 'top-right';
    this.toastaConfig.limit = 100;
    this.toastaConfig.showClose = true;

  }


  ngAfterViewInit() {
    console.log('ngAfterViewInit fired');
    this.modalLoginControls.changes.subscribe((controls: QueryList<any>) => {
      controls.forEach(control => {
        if (control) {
          if (control instanceof LoginComponent) {
            this.loginControl = control;
            this.loginControl.modalClosedCallback = () => this.loginModal.hide();
          } else {
            this.loginModal = control;
            this.loginModal.show();
          }
        }
      });
    });
  }


  onLoginModalShown() {
    this.alertService.showStickyMessage('Session Expired', 'Your Session has expired. Please log in again', MessageSeverity.info);
  }


  onLoginModalHidden() {
    this.alertService.resetStickyMessage();
    this.loginControl.reset();
    this.shouldShowLoginModal = false;

    if (this.authService.isSessionExpired) {
      this.alertService.showStickyMessage('Session Expired', 'Your Session has expired. Please log in again to renew your session', MessageSeverity.warn);
    }
  }


  onLoginModalHide() {
    this.alertService.resetStickyMessage();
  }


  ngOnInit() {
    console.log('ngOnInit fired');
    console.log('this.authService.isLoggedIn ' + this.authService.isLoggedIn);
    this.isUserLoggedIn = this.authService.isLoggedIn;

    // 0.5 extra sec to display preboot/loader information. Preboot screen is removed 0.5 sec later
    setTimeout(() => this.isAppLoaded = true, 500);
    setTimeout(() => this.removePrebootScreen = true, 1000);

    setTimeout(() => {
      if (this.isUserLoggedIn) {
        this.alertService.resetStickyMessage();

        // if (!this.authService.isSessionExpired)
        this.alertService.showMessage('Login', `Welcome back ${this.userName}!`, MessageSeverity.default);
        // else
        //    this.alertService.showStickyMessage("Session Expired", "Your Session has expired. Please log in again", MessageSeverity.warn);
      }
    }, 2000);


    this.alertService.getDialogEvent().subscribe(alert => this.showDialog(alert));
    this.alertService.getMessageEvent().subscribe(message => this.showToast(message));

    this.authService.reLoginDelegate = () => this.shouldShowLoginModal = true;

    this.authService.getLoginStatusEvent().subscribe(isLoggedIn => {
      this.isUserLoggedIn = isLoggedIn;


      if (this.isUserLoggedIn) {
       // this.initNotificationsLoading();
      } else {
       // this.unsubscribeNotifications();
      }

      setTimeout(() => {
        if (!this.isUserLoggedIn) {
          this.alertService.showMessage('Session Ended!', '', MessageSeverity.default);
        }
      }, 500);
    });
  }


  ngOnDestroy() {
    this.unsubscribeNotifications();
   
  }


  private unsubscribeNotifications() {
    if (this.notificationsLoadingSubscription) {
      this.notificationsLoadingSubscription.unsubscribe();
    }
  }



  //initNotificationsLoading() {

  //  this.notificationsLoadingSubscription = this.notificationService.getNewNotificationsPeriodically()
  //    .subscribe(notifications => {
  //      this.dataLoadingConsecutiveFailures = 0;
  //      this.newNotificationCount = notifications.filter(n => !n.isRead).length;
  //    },
  //      error => {
  //        this.alertService.logError(error);

  //        if (this.dataLoadingConsecutiveFailures++ < 20) {
  //          setTimeout(() => this.initNotificationsLoading(), 5000);
  //        } else {
  //          this.alertService.showStickyMessage('Load Error', 'Loading new notifications from the server failed!', MessageSeverity.error);
  //        }
  //      });
  //}


  //markNotificationsAsRead() {

  //  const recentNotifications = this.notificationService.recentNotifications;

  //  if (recentNotifications.length) {
  //    this.notificationService.readUnreadNotification(recentNotifications.map(n => n.id), true)
  //      .subscribe(response => {
  //        for (const n of recentNotifications) {
  //          n.isRead = true;
  //        }

  //        this.newNotificationCount = recentNotifications.filter(n => !n.isRead).length;
  //      },
  //        error => {
  //          this.alertService.logError(error);
  //          this.alertService.showMessage('Notification Error', 'Marking read notifications failed', MessageSeverity.error);

  //        });
  //  }
  //}



  showDialog(dialog: AlertDialog) {

    alertify.set({
      labels: {
        ok: dialog.okLabel || 'OK',
        cancel: dialog.cancelLabel || 'Cancel'
      }
    });

    switch (dialog.type) {
      case DialogType.alert:
        alertify.alert(dialog.message);

        break;
      case DialogType.confirm:
        alertify
          .confirm(dialog.message, (e) => {
            if (e) {
              dialog.okCallback();
            } else {
              if (dialog.cancelCallback) {
                dialog.cancelCallback();
              }
            }
          });

        break;
      case DialogType.prompt:
        alertify
          .prompt(dialog.message, (e, val) => {
            if (e) {
              dialog.okCallback(val);
            } else {
              if (dialog.cancelCallback) {
                dialog.cancelCallback();
              }
            }
          }, dialog.defaultValue);

        break;
    }
  }



  showToast(alert: AlertCommand) {

    if (alert.operation == 'clear') {
      for (const id of this.stickyToasties.slice(0)) {
        this.toastaService.clear(id);
      }

      return;
    }

    const toastOptions: ToastOptions = {
      title: alert.message.summary,
      msg: alert.message.detail,
    };


    if (alert.operation == 'add_sticky') {
      toastOptions.timeout = 0;

      toastOptions.onAdd = (toast: ToastData) => {
        this.stickyToasties.push(toast.id);
      };

      toastOptions.onRemove = (toast: ToastData) => {
        const index = this.stickyToasties.indexOf(toast.id, 0);

        if (index > -1) {
          this.stickyToasties.splice(index, 1);
        }

        if (alert.onRemove) {
          alert.onRemove();
        }

        toast.onAdd = null;
        toast.onRemove = null;
      };
    } else {
      toastOptions.timeout = 4000;
    }


    switch (alert.message.severity) {
      case MessageSeverity.default: this.toastaService.default(toastOptions); break;
      case MessageSeverity.info: this.toastaService.info(toastOptions); break;
      case MessageSeverity.success: this.toastaService.success(toastOptions); break;
      case MessageSeverity.error: this.toastaService.error(toastOptions); break;
      case MessageSeverity.warn: this.toastaService.warning(toastOptions); break;
      case MessageSeverity.wait: this.toastaService.wait(toastOptions); break;
    }
  }



  logout() {
    this.isUserLoggedIn = false;
    this.authService.logout();
    this.authService.redirectForLogin();
  }


  getYear() {
    return new Date().getUTCFullYear();
  }


  get userName(): string {
    return this.authService.currentUser ? this.authService.currentUser.email : '';
  }


  get fullName(): string {
    return this.authService.currentUser ? this.authService.currentUser.name : '';
  }
  
  get canViewCustomers() {
    return true; // eg. viewCustomersPermission
  }

  get canViewUsers() {
    return this.authService.isAdmin ? this.authService.isAdmin : false;
  }

  get canViewProducts() {
    return this.authService.isAdmin ? this.authService.isAdmin : false;
  }

}
