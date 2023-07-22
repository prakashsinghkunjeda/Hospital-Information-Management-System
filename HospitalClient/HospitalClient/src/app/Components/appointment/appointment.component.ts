import { Component, ViewChild } from '@angular/core';
import { Appointment } from '../../Model/Appointment';
import { ApiService } from '../../Service/api.service';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent {
  appointment: Appointment=new Appointment();
  
  @ViewChild('closebutton')closebutton:any;
  doctorList: any;
  doctorId: any;

  appointmentList: any;

  constructor(private _service:ApiService) { 
  }
  ngOnInit(): void {
    this.listAppointment();
    this.listDoctor();
  }

  addAppPatient(){
    this._service.postAppointmentPatient(this.appointment).subscribe(
      res=>{
        alert("Appointment added Successfully");
        this.listAppointment();
        this.closebutton.nativeElement.click();// closing modal 
      },
      err=>{
        alert("failed to add new appointment");
          console.log(err);
      }
    );
  }

  listAppointment(){
    this._service.getappoinmentPatient().subscribe(
      res=>{
        this.appointmentList=res;
      },
      err=>{
  
      }
    )
  }
  listDoctor(){
    this._service.getDoctor().subscribe(
      res =>{
       this.doctorList=res;
       
      },
      err =>{
       console.log(err);
      }
    );
  }
  onDoctorChange(event:any){
    this.doctorId=event.target.value;
    this.appointment.DoctorId=this.doctorId;
  }
}
