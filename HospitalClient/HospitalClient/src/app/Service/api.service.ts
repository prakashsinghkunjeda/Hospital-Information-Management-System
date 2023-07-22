import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import{Doctor} from '../Model/doctorModel'
import { Patient } from '../Model/patientModel';
import { PatientProblem } from '../Model/PatinetProblem';
import { Medication } from '../Model/Medication';
import { Appointment } from '../Model/Appointment';
import { Login } from '../Model/Login';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private _http:HttpClient) { }
  postDoctor(doctorParam:Doctor):Observable<any>{
   return this._http.post("https://localhost:7241/api/Doctor",doctorParam,{responseType:'json'});
  }
  getDoctor():Observable<any>{
    return this._http.get("https://localhost:7241/api/Doctor",{responseType:'json'});
  }

  getDoctorById(id:number):Observable<any>{
    return this._http.get("https://localhost:7241/api/Doctor/"+id,{responseType:'json'});  }


    updateDoctor(id:number,doctor:Doctor):Observable<any>{
      return this._http.put("https://localhost:7241/api/Doctor/"+id,doctor,{responseType:'json'});  }

  deleteDoctor(id:number):Observable<any>
  {
    return this._http.delete("https://localhost:7241/api/Doctor/"+id,{responseType:'json'});  }

  deletePatient(id:number):Observable<any>
  {
    return this._http.delete("https://localhost:7241/api/Patient/"+id,{responseType:'json'});  }

  postPatient(patient:Patient):Observable<any>
  {
    return this._http.post("https://localhost:7241/api/Patient",patient,{responseType:'json'});  
  }
  postAppointmentPatient(appointment:Appointment):Observable<any>
  {
    return this._http.post("https://localhost:7241/api/Appointment",appointment,{responseType:'json'});  
  }
  getPatient():Observable<any>
  {
    return this._http.get("https://localhost:7241/api/Patient",{responseType:'json'});
  }
  getProblem(id:number):Observable<any>{
    return this._http.get("https://localhost:7241/api/PatientProblem/"+id,{responseType:'json'});
  }
  getappoinmentPatient():Observable<any>
  {
    return this._http.get("https://localhost:7241/api/Appointment",{responseType:'json'});
  }

  getPatientById(id:number):Observable<any>{
    return this._http.get("https://localhost:7241/api//Patient/"+id,{responseType:'json'})
}
  postPatientProblem(problem:PatientProblem):Observable<any>
  {
    return this._http.post("https://localhost:7241/api/PatientProblem",problem,{responseType:'json'});
  }

  postMedication(medication:Medication):Observable<any>{
    return this._http.post("https://localhost:7241/api/Medication",medication,{responseType:'json'});

  }

  Login(loginRequest:Login):Observable<any>{
    return this._http.post("https://localhost:7241/api/Authentication/Login",loginRequest,{responseType:'json'});
  }
  }


