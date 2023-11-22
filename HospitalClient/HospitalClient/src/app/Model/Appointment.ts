import { AbstractControl, FormBuilder, FormGroup, Validators } from "@angular/forms";

export class Appointment{

    public FirstName: string="";
    public LastName: String="";
    public Address : String="";
    public Contact:  String="";
    public Age:number=0;
    public DoctorId:number=0;
    public VisitDate: String=''
    public AppointmentFormGroup :FormGroup
       constructor(){
             let formBuilder:FormBuilder=new FormBuilder();
          this.AppointmentFormGroup=formBuilder.group({
               FirstName:['',[Validators.required]],
                Address:['',[Validators.required]],
                LastName:['',[Validators.required]],
                Contact:['',Validators.compose([Validators.required,Validators.pattern('^[0-9]{10,10}$')])],
                Age:['',Validators.required],
                DoctorId:['',Validators.required],
                VisitDate:['',[Validators.required]]

               //VisitDate:['',[Validators.required,this.validateDateNotInPast.bind(this)]]
          })
          
    
       }
    //    validateDateNotInPast(control: AbstractControl): { [key: string]: boolean } | null {
    //     const VisitDate = new Date(control.value);
    //     const today = new Date();
    
    //     if (VisitDate < today) {
    //       return { invalidDate: true };
    //     }
    
    //     return null;
    //   }
    
}



function moment() {
    throw new Error("Function not implemented.");
}


