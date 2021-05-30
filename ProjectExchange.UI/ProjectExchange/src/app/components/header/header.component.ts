import { Component, Input, OnInit } from '@angular/core';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public ProjectName = "Project: Exchange v1";
  public isAuthenticated: boolean;

  constructor() {
    //this.isAuthenticated = this.authenticationService.isAuthenticated();

    this.isAuthenticated = true;
  }
  ngOnInit(): void {
  }

  logout() {
    this.isAuthenticated = false;
  }
}
