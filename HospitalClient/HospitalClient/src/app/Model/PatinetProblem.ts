import { FormBuilder, FormGroup, Validators } from "@angular/forms"

export class PatientProblem{
    public Problem:string="";
    public ProblemVisitDate: string="";
     public ProblemMedications: string="";
    public PatientId: number = 0;
    public ProblemGroup:FormGroup;

    constructor(){
        let formBuilder=new FormBuilder();
        this.ProblemGroup= formBuilder.group({
            Problem:['',Validators.required],
            PatientId:['',Validators.required],
            ProblemVisitDate:['',Validators.required],
            ProblemMedications:['',Validators.required]
        });
    }
}