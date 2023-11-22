import { Component, ViewChild } from '@angular/core';
import { Appointment } from '../../Model/Appointment';
import { ApiService } from '../../Service/api.service';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent {
  appointment: Appointment=new Appointment();
  public AppointmentFormGroup: FormGroup;
  
  @ViewChild('closebutton')closebutton:any;
  doctorList: any;
  doctorId: any;

  appointmentList: any;

  constructor(private _service:ApiService,private fb: FormBuilder) { 
    this.AppointmentFormGroup = this.fb.group({
      // Your other form controls
      VisitDate: ['', [Validators.required, this.validateDateNotInPast.bind(this)]],
    });
  }
  validateDateNotInPast(control: AbstractControl): { [key: string]: boolean } | null {
    const visitDate = new Date(control.value);

    // Check if the value is a valid date
    if (isNaN(visitDate.getTime())) {
      return { invalidDate: true };
    }

    const today = new Date();

    if (visitDate < today) {
      return { invalidDate: true };
    }

    return null;
  }
  minDateToday(): string {
    const today = new Date();
    return today.toISOString().split('T')[0];
  }

  ngOnInit(): void {
    this.listAppointment();
    this.listDoctor();
  }


  addAppPatient(){
    let appValue:Appointment = new Appointment();
    appValue= this.appointment.AppointmentFormGroup.value;
    this._service.postAppointmentPatient(appValue).subscribe(
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
