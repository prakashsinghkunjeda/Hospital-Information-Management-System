import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppointmentComponent } from '../Components/appointment/appointment.component';
import { DoctorComponent } from "../Components/doctor/doctorComponent"
import { PatientComponent } from '../Components/patient/patient.component';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { authInterceptorProviders } from '../Service/interceptor';
import { AuthGuardService } from '../Service/AuthGaurd';


@NgModule({
  declarations: [
    HomeComponent,
    DoctorComponent,
    PatientComponent,
    AppointmentComponent
    ],

  imports: [
    CommonModule,
    HomeRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [authInterceptorProviders,AuthGuardService],
  bootstrap: [HomeComponent]
})
export class HomeModule { }
