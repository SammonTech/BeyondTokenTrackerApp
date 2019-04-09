import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user.model';
import { UserEndpoint } from '../services/user-endpoint.service';
import { ConfigurationService } from '../services/configuration.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  public users: User[];

  constructor(private httpClient: HttpClient, private userEndpoint: UserEndpoint, protected configurations: ConfigurationService) { }

  ngOnInit() {

    this.userEndpoint.getUsersEndpoint().subscribe(x => {
      console.log("all users: ", x);
    });

  }

}
