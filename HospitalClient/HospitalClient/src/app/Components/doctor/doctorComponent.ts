import { Component, OnInit, ViewChild } from '@angular/core';
import { Doctor } from '../../Model/doctorModel';
import { ApiService } from '../../Service/api.service';


@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {
   public doctor: Doctor=new Doctor();   
   public doctorList: any;
   public doctorRow: any;
   isDoctorSelected:boolean =false;
   @ViewChild('closebutton')closebutton:any;// for closeing the modal after data manipulation to make user friendly UI.
   @ViewChild('close')close:any; //For edit.  #close refrence 
   @ViewChild('closedelete') closedelete:any;
  doctorId: any;
  constructor( private _apiService:ApiService) {
  }
  ngOnInit(): void 
  {
    this.listDoctor();
  }
  addDoctor()
  {  
    let doctorValue:Doctor = new Doctor();
    doctorValue=this.doctor.DoctorFormGroup.value;
     this._apiService.postDoctor(doctorValue).subscribe(
      res=>{
        alert("Doctor added Successfully");
        this.listDoctor();
        this.closebutton.nativeElement.click();// closing modal 
      },
      err=>{
        alert("failed to add new doctor");
        console.log(err);
      }
     );
  }
  listDoctor(){
    this._apiService.getDoctor().subscribe(
      res =>{
       this.doctorList=res;
       //console.log(this.doctorList);
      },
      err =>{

      }
    );
  }

  selectedDoctor(id:number){
    this.isDoctorSelected=true;//to only tigger it when edit button is clicked so that editform is igonred at run time.
    this.fetchDoctorId(id);
    this._apiService.getDoctorById(id).subscribe(
      res=>{
        this.doctorRow=res;
        this.doctor.DoctorFormGroup.controls['FirstName'].setValue(this.doctorRow.FirstName);
        this.doctor.DoctorFormGroup.controls['LastName'].setValue(this.doctorRow.LastName);
        this.doctor.DoctorFormGroup.controls['Address'].setValue(this.doctorRow.Address);
        this.doctor.DoctorFormGroup.controls['PhoneNumber'].setValue(this.doctorRow.PhoneNumber);
        this.doctor.DoctorFormGroup.controls['Specialist'].setValue(this.doctorRow.Specialist);
      },
      err=>{

      }
    )
  }
  editDoctor(){
    let doctorValue:Doctor = new Doctor();
    doctorValue=this.doctor.DoctorFormGroup.value;
    this._apiService.updateDoctor(this.doctorId,doctorValue).subscribe(
      res=>{
        this.listDoctor();
        alert("Updated Successfully");
        this.close.nativeElement.click();
        

      },
      err=>{
   
      }
    )
  }
  fetchDoctorId(id:number)
  {
    this.doctorId=id;
  }
  removeDoctor()
  {
    this._apiService.deleteDoctor(this.doctorId).subscribe(
      res=>{
        this.listDoctor();
        this.closedelete.nativeElement.click();
      },
      err=>{

        console.log(err);
      }
    )
  }
}

