import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  model2: any = {};
  model3: any = {};
  x = 0;
  y = 0;
  z = 0;
  a = 0;

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
  }
  // tslint:disable-next-line:typedef
  loginasadmin() {
    this.x = 1;
  }
  // tslint:disable-next-line:typedef
  backbutton() {
    this.x = 0;
  }

  // tslint:disable-next-line:typedef
  loginasdoctor() {
    this.x = 2;
  }

  // tslint:disable-next-line:typedef
  loginaspatient() {
    this.x = 3;
  }

  // tslint:disable-next-line:typedef
  logintosystemasadmin() {
    this.authService.loginadmin(this.model).subscribe(next => {
      this.alertify.success('Logged in as admin successfully');
    }, error => {
      this.alertify.error('Failed to login as admin');
    }, () => {
      this.router.navigate(['/add-doctor']);
    });

  }

  // tslint:disable-next-line:typedef
  logintosystemasdoctor() {
    this.authService.logindoctor(this.model2).subscribe(next => {
      this.alertify.success('Logged in as doctor successfully');
    }, error => {
      this.alertify.error('Failed to login as doctor');
    }, () => {
      this.router.navigate(['/details']);
    });
  }

  // tslint:disable-next-line:typedef
  logintosystemaspatient(){
    this.authService.loginpatient(this.model3).subscribe(next => {
     this.alertify.success('Logged in as patient successfully');
    }, error => {
      this.alertify.error('Failed to login as patient');
    }, () => {
      this.router.navigate(['/view-doctors']);
    });


  }

  // tslint:disable-next-line:typedef
  loggedInasadmin(){

    const token = localStorage.getItem('token');
    return !!token;
  }
   // tslint:disable-next-line:typedef
   loggedInasdoctor(){

    const token2 = localStorage.getItem('token');
    return !!token2;
  }

   // tslint:disable-next-line:typedef
   loggedInaspatient(){

    const token3 = localStorage.getItem('token');
    return !!token3;
  }

  // tslint:disable-next-line:typedef
  logout(){
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);

  }

  // tslint:disable-next-line:typedef
  logoutadmin(){
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.y = 0;
    this.router.navigate(['/home']);

  }

  // tslint:disable-next-line:typedef
  logoutdoctor() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.z = 0;
    this.router.navigate(['/home']);
  }

  // tslint:disable-next-line:typedef
  logoutpatient() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.a = 0;
    this.router.navigate(['/home']);
  }

  // tslint:disable-next-line:typedef
  loginadmin(){
    this.y = 1;

  }

  // tslint:disable-next-line:typedef
  logindoctor(){
    this.z = 1;
  }

  // tslint:disable-next-line:typedef
  loginpatient(){
    this.a = 1;
  }


}
