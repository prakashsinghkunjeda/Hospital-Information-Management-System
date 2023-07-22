import { Component, OnInit, ViewChild } from '@angular/core';
import { Doctor } from '../../Model/doctorModel';
import { Patient} from '../../Model/patientModel';
import { ApiService } from '../../Service/api.service';
import { PatientProblem } from '../../Model/PatinetProblem';
import { Medication } from '../../Model/Medication';
import { identifierName } from '@angular/compiler';

@Component({
  selector: 'app-patient',
  templateUrl:'./patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit{
  patient :Patient=new Patient();
  problem : PatientProblem = new PatientProblem();
  doctorList:any;
  doctorId: any;
  patientList: any;
  patientRow:Patient=new Patient();
  doctorFname: any;
  doctorLname: any;
  docId: any;
  medication: Medication = new Medication();
  @ViewChild('closebutton')closebutton:any;
  @ViewChild('closebuttons')closebuttons:any;
  @ViewChild('closedelete')closedelete:any;
  
  patientId: number=0;
  problemList: any;
  
constructor(private _service:ApiService) { 
}
ngOnInit(): void {
    this.listPatient();
    this.listDoctor();
}
addPatient(){
  this._service.postPatient(this.patient).subscribe(
    res=>{
      alert("Patinet added Successfully");
      this.listPatient();
      this.closebutton.nativeElement.click();// closing modal 
    },
    err=>{
      alert("failed to add new patient");
        console.log(err);
    }
  );
}

listPatientRow(id:number) {
  this._service.getPatientById(id).subscribe(
    res => {
      this.patientRow = res;
      this.doctorFname=res.Doctor.FirstName;
      this.docId=res.Doctor.DoctorId;
      this.doctorLname=res.Doctor.LastName;
      console.log(this.patientRow);
    },
    err=>{
      console.log(err);
    }
  );
}
addPatientProblem(){
  this.problem.ProblemGroup.controls['PatientId'].setValue(this.patientId);
let problemValue =this.problem.ProblemGroup.value
this._service.postPatientProblem(problemValue).subscribe(
  res=>{
    alert("Problem added Successfully");
    this.closebuttons.nativeElement.click();// closing modal 

  },
  err=>{
    console.log(err);
  }
)
}
listPatient(){
  this._service.getPatient().subscribe(
    res=>{
      this.patientList=res;
    },
    err=>{

    }
  )
}

listProblem(id:number){
  this._service.getProblem(this.patientId).subscribe(
    res=>{
      this.problemList=res;
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
  this.patient.DoctorId=this.doctorId;
}


fetchId(id:number){
  this.patientId=id;
}


removePatient()
{
  this._service.deletePatient(this.patientId).subscribe(
    res=>{
      this.listPatient();
      this.closedelete.nativeElement.click();
    },
    err=>{

      console.log(err);
    }
  )
}
}

