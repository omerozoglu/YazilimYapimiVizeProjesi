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
  }
  ngOnInit(): void {
    if (localStorage.getItem('id')) {
      this.isAuthenticated = true;
    } else {
      this.isAuthenticated = false;
    }
  }

  logout() {
    localStorage.removeItem("id");
    localStorage.removeItem("name");
    localStorage.removeItem("email");
    localStorage.removeItem("address");
    localStorage.removeItem("tcnumber");
    localStorage.removeItem("phone");
    localStorage.removeItem("credit");
    localStorage.removeItem("accounttype");
    this.isAuthenticated = false;
  }
}
