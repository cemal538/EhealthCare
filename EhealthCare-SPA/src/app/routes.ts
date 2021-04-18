import {Routes} from '@angular/router';
import { AddDoctorComponent } from './add-doctor/add-doctor.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { ChatWithDoctorComponent } from './chat-with-doctor/chat-with-doctor.component';
import { ChatWithPatientsComponent } from './chat-with-patients/chat-with-patients.component';
import { DetailsComponent } from './details/details.component';
import { GiveFeedbackComponent } from './give-feedback/give-feedback.component';
import { HomeComponent } from './home/home.component';
import { ViewDoctorsComponent } from './view-doctors/view-doctors.component';
import { ViewFeedbackComponent } from './view-feedback/view-feedback.component';
import { ViewPatientsComponent } from './view-patients/view-patients.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    {path : 'home', component: HomeComponent},
    {path : 'add-doctor', component: AddDoctorComponent, canActivate: [AuthGuard]},
    {path : 'add-patient', component: AddPatientComponent, canActivate: [AuthGuard]},
    {path : 'view-doctors', component: ViewDoctorsComponent, canActivate: [AuthGuard]},
    {path : 'view-patients', component: ViewPatientsComponent, canActivate: [AuthGuard]},
    {path : 'view-feedback', component: ViewFeedbackComponent, canActivate: [AuthGuard]},
    {path : 'details', component: DetailsComponent, canActivate: [AuthGuard]},
    {path : 'chat-with-patients', component: ChatWithPatientsComponent, canActivate: [AuthGuard]},
    {path : 'chat-with-doctor', component: ChatWithDoctorComponent, canActivate: [AuthGuard]},
    {path : 'give-feedback', component: GiveFeedbackComponent, canActivate: [AuthGuard]},
    {path : '**', redirectTo: 'home' , pathMatch: 'full'}
];
