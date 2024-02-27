import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo.model';
import { TodoService } from '../../services/todo.service';
import { MatDialog } from '@angular/material/dialog';
import { EditTodoComponent } from '../edit-todo/edit-todo.component';
import { AddtodoComponent } from '../addtodo/addtodo.component';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { TaskAssignComponent } from '../task-assign/task-assign.component';
import { ActivatedRoute } from '@angular/router';
import { warn } from 'console';

interface PriorityOption {
  value: string;
  viewValue: string;
}
@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrl: './todos.component.css'
})
export class TodosComponent implements OnInit{

  priorityOptions: PriorityOption[] = [
    { value: 'Prioritys', viewValue: 'PRIORITY' },
    { value: 'DueDate', viewValue: 'DUE DATE' },
    { value: 'CreatedOn', viewValue: 'CREATE TIME' },
  ];
  completedTask!:number
  inCompletedTask!:number
  value = '';
  user_name!: string;
  user_id!:number;
  myObj!:EditTodoComponent
  todos: Todo[]= [];
   newTodo: Todo = {
    taskId:0,
    id: 0,
    title: '',
    descriptions: '',
    isCompleted: 0,
    createdOn: new Date() ,
    dueDate: new Date(),
    prioritys:''
  };

  filterOption!:string

  // toppings = this._formBuilder.group({
    
  //   isComplete: false,
    
  // });

  


  constructor(private todoService: TodoService,
    private _dialog : MatDialog,
    //  private _edit:EditTodoComponent
    private _formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
   
    ) {}
  ngOnInit(): void {

    
    
    this.route.queryParams.subscribe(params => {
      this.user_name = params['user'];
      this.user_id= params['id']
      
    });
    console.log(this.user_id)

    // warn(this.data)
    if(this.filterOption !=null){
       this.GetAllTodosUsingFilter()
       
    }else{
      this.getAllTodos();
      
    }
    

    
    
  }


  openAddTodoForm(){
    const dialogRef=  this._dialog.open(AddtodoComponent,{
      data: { id:this.user_id }
    });
    dialogRef.afterClosed().subscribe({
     next:(val)=>{
       if(val){
         this.todoService.getAllTodos(this.user_id);
       }
     }
    });
   }
  
  checkBox(todo:Todo){
    if(todo.isCompleted==1) todo.isCompleted=0
    else todo.isCompleted=1
    
    this.todoService.statusUpdateTodo(todo)
    .subscribe({
      next:(todo)=>{
        this.getAllTodos();
      }
    });
  }

  getAllTodos(){
    this.todoService.getAllTodos(this.user_id)
    .subscribe({
      next: (todos) => {
        this.todos = todos;
        this.completedTask=0
        console.log(this.todos)
        for(let todo of this.todos){
          if(todo.isCompleted){
            this.completedTask++;
          }
        }
        this.inCompletedTask=todos.length-this.completedTask
        console.log(this.inCompletedTask)
        // add 
        
       // this.toppings.patchValue({  });
      }
    });
  }

  // addTodo(){
  //   this.todoService.addTodo(this.newTodo)
  //   .subscribe({
  //    next: (todos) => {
        
       
  //    }
  //   });
  //  }
   deleteTodo(id:number,task_id:number){
    console.log(this.newTodo)
     this.todoService.deleteTodo(id,task_id)
     .subscribe({
      next: (response)=>{
        this.getAllTodos();
      }
     })
   }


   

   editTodo(todo:Todo){
     
    const dialogRef = this._dialog.open(EditTodoComponent, {
      data: { todo: todo }
    });

    dialogRef.afterClosed().subscribe(result => {
      // Handle 
    });
    
   }
   taskAssign(todo:Todo){
    
    const dialogRef = this._dialog.open(TaskAssignComponent, {
      data: { todo: todo }
    });

    dialogRef.afterClosed().subscribe(result => {
      // Handle 
    });
   }

   GetAllTodosUsingFilter(){
    
    console.log(this.filterOption)
    if(this.filterOption!=null){
      this.todoService.getAllTodosUsingFilter(this.filterOption,this.user_id)
      .subscribe({
          next: (todo)=>{
            this.todos=todo;
            console.log(todo);
            console.log(this.newTodo)
          }
      })
    }
   
   }

   searchOption (){
      if(this.value.length==0){
        this.getAllTodos();
      }else{
        this.todoService.searchInTodo(this.value,this.user_id)
        .subscribe({
          next:(todos)=>{
            this.todos=todos;
          }
        })
      }
    
   }
   searchClear(){
     this.getAllTodos();
   }


   GetAllTodosUsingStatus(filterOption:number){
      console.log(filterOption)
      this.todoService.GetAllTodosUsingStatus(filterOption,this.user_id)
      .subscribe({
        next:(todo)=>{
            this.todos=todo;
        }
      });
   }

   
  
}
