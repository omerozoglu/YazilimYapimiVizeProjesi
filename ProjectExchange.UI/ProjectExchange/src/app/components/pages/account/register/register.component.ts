import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountType } from 'src/app/models/Enums/account-type';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  user: User = new User();
  isClick: number = 0;
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {

  }

  public addFirstInfo(name, username, email, pass, pass2) {
    this.user.name = name;
    this.user.username = username;
    this.user.email = email;
    if (pass == pass2) {
      this.user.password = pass;
      this.isClick = 1;
    } else {
      // toats warrining
      this.isClick = 0;
    }
  }
  public addSecondInfo(taker?, seller?) {
    this.user.accountType = [];
    if (taker) {
      this.user.accountType.push(AccountType.Taker.value);
      this.isClick = 2;
    }
    if (seller) {
      this.user.accountType.push(AccountType.Selller.value);
      this.isClick = 2;
    }
    if (!taker && !seller) {
      //toats warrining
      this.isClick = 1;
    }
  }
  public addThirtInfo(tcnu, phone, address) {
    this.user.tcNumber = tcnu;
    this.user.phone = phone;
    this.user.address = address;
    this.userService.createUser(this.user).subscribe(p => {
      this.router.navigate(['/']);
    });
  }
}
