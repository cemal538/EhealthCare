import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5000/auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  decodedToken2: any;
  decodedToken3: any;

constructor(private http: HttpClient) { }

// tslint:disable-next-line:typedef
loginadmin(model: any) {
  return this.http.post(this.baseUrl + 'loginadmin', model)
  .pipe(
    map((response: any) => {
      const admin = response;
      if (admin){
         localStorage.setItem('token', admin.token);
         this.decodedToken = this.jwtHelper.decodeToken(admin.token);
         console.log(this.decodedToken);
      }
    })
  );
}
// tslint:disable-next-line:typedef
logindoctor(model2: any) {
  return this.http.post(this.baseUrl + 'logindoctor', model2)
  .pipe(
    map((response: any) => {
      const doctor = response;
      if (doctor){
         localStorage.setItem('token', doctor.token);
         this.decodedToken2 = this.jwtHelper.decodeToken(doctor.token);
         console.log(this.decodedToken2);
      }
    })
  );
}
// tslint:disable-next-line:typedef
loginpatient(model3: any) {
  return this.http.post(this.baseUrl + 'loginpatient', model3)
  .pipe(
    map((response: any) => {
      const patient = response;
      if (patient){
         localStorage.setItem('token', patient.token);
         this.decodedToken3 = this.jwtHelper.decodeToken(patient.token);
         console.log(this.decodedToken3);
      }
    })
  );
}


}
