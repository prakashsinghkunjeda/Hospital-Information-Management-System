import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentComponent } from '../Components/appointment/appointment.component';
import { DoctorComponent } from "../Components/doctor/doctorComponent";
import { PatientComponent } from '../Components/patient/patient.component';
import { HomeComponent } from './home.component';
import { AuthGuardService } from '../Service/AuthGaurd';
import { DashboardComponent } from '../Components/dashboard/dashboard.component';

const routes: Routes = [

  {
    path:"",component:HomeComponent ,children:
    [ 
      {
        path:"", redirectTo:"#",pathMatch:"full"
      },
      {
         path:"#", component:HomeComponent, canActivate:[AuthGuardService]
      },
      {
        path:"doctor",component:DoctorComponent, canActivate:[AuthGuardService]
      },
      {
        path:"patient", component:PatientComponent, canActivate:[AuthGuardService]
      },
      {
        path: "appointment", component:AppointmentComponent, canActivate:[AuthGuardService]
      },
      {
        path: "dashboard", component:DashboardComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
