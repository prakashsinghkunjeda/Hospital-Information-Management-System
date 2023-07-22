import { FormBuilder, FormGroup, Validators } from "@angular/forms";

export class Medication{
    public Medicine: string="";
    public ProblemId:number=0;
    public MedicationGroup:FormGroup;

    constructor (){
        let formBuilder= new FormBuilder();
        this.MedicationGroup=formBuilder.group({
            Medicine:['',Validators.required],
            ProblemId: ['',Validators.required]
        })
    }
}