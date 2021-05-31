import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public user: User = new User();
  constructor(private userService: UserService, private router: Router) { }
  ngOnInit(): void {
  }

  public Login(username, pass) {
    let user: User = new User();
    if (typeof username != 'undefined' && typeof pass != 'undefined') {
      user.username = username;
      user.password = pass;
      this.userService.login(user).subscribe(p => {
        if (p.username == null) {
          //Toats warning
        } else {
          localStorage.setItem("id", p.id);
          localStorage.setItem("name", p.name);
          localStorage.setItem("email", p.email);
          localStorage.setItem("address", p.address);
          localStorage.setItem("tcnumber", p.tcNumber);
          localStorage.setItem("phone", p.phone);
          localStorage.setItem("credit", p.credit.toString());
          localStorage.setItem("accounttype", p.accountType.toString());
          this.router.navigate(['/']);
        }
      });
    }
    else {
      //Toast warrning
    }
  }
  public Logout() {
    localStorage.removeItem("id");
    localStorage.removeItem("name");
    localStorage.removeItem("email");
    localStorage.removeItem("address");
    localStorage.removeItem("tcnumber");
    localStorage.removeItem("phone");
    localStorage.removeItem("credit");
    localStorage.removeItem("accounttype");
  }
}
