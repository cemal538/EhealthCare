import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';

import { BrowserModule } from '@angular/platform-browser';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { AddDoctorComponent } from './add-doctor/add-doctor.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { ViewDoctorsComponent } from './view-doctors/view-doctors.component';
import { ViewPatientsComponent } from './view-patients/view-patients.component';
import { ViewFeedbackComponent } from './view-feedback/view-feedback.component';
import { DetailsComponent } from './details/details.component';
import { ChatWithDoctorComponent } from './chat-with-doctor/chat-with-doctor.component';
import { ChatWithPatientsComponent } from './chat-with-patients/chat-with-patients.component';
import { GiveFeedbackComponent } from './give-feedback/give-feedback.component';
import { HomeComponent } from './home/home.component';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';



@NgModule({
  declarations: [
      AppComponent,
      ValueComponent,
      NavComponent,
      HomeComponent,
      AddDoctorComponent,
      AddPatientComponent,
      ViewDoctorsComponent,
      ViewPatientsComponent,
      ViewFeedbackComponent,
      DetailsComponent,
      ChatWithDoctorComponent,
      ChatWithPatientsComponent,
      GiveFeedbackComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    AuthService,
    AlertifyService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
 }
