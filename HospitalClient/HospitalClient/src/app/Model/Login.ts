
import { FormBuilder, FormControl, FormGroup, NgForm, Validators} from "@angular/forms";
export class Login{
        public Username:string = "";
        public Password:string = "";
        public LoginForm: FormGroup;

        constructor(){
            let formBuilder = new FormBuilder();
            this.LoginForm = formBuilder.group({
                Username:['', [Validators.required]],
                Password:['',Validators.compose([Validators.required,  Validators.pattern ('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}') ])]
            });
        
         }
 }