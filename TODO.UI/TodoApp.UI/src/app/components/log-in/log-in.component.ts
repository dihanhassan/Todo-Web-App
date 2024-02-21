import { Component, OnInit } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { Login } from '../../models/login.model';

import { Router } from '@angular/router';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrl: './log-in.component.css'
})
export class LogInComponent implements OnInit{
  username: string = '';
  password: string = '';

  credential:Login={
    id:0,
    userName:'',
    userPassword:''
  }
  validition:string=''
  constructor(private service : TodoService , private router: Router ){}

  ngOnInit(): void {
    
  }

  onSubmit() {
    // Add your authentication logic here
    
    this.service.userValidition(this.credential).subscribe({
      next:(login)=>{
        
        if(login!=null && login.userName===this.credential.userName &&   login.userPassword === this.credential.userPassword){
          console.log("Hello")
          
          this.router.navigate(['/todos'],{ queryParams: { user: this.credential.userName , id:login.id} });
        }else{
          alert("Failed");
        }
      }
    });
  }
}
