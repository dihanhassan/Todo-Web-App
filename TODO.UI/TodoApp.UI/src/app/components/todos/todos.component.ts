import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo.model';
import { TodoService } from '../../services/todo.service';
import { MatDialog } from '@angular/material/dialog';
import { EditTodoComponent } from '../edit-todo/edit-todo.component';
import { AddtodoComponent } from '../addtodo/addtodo.component';
import { FormBuilder } from '@angular/forms';
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

  myObj!:EditTodoComponent
  todos: Todo[]= [];
   newTodo: Todo = {
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
    private _formBuilder: FormBuilder
   
    ) {}
  ngOnInit(): void {
    //this.getAllTodos();
   
    if(this.filterOption !=null){
       this.GetAllTodosUsingFilter()
    }else{
      this.getAllTodos();
    }

    
    
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
    this.todoService.getAllTodos()
    .subscribe({
      next: (todos) => {
        this.todos = todos;
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
   deleteTodo(id:number){
     this.todoService.deleteTodo(id)
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

   GetAllTodosUsingFilter(){
    
    console.log(this.filterOption)
    if(this.filterOption!=null){
      this.todoService.getAllTodosUsingFilter(this.filterOption)
      .subscribe({
          next: (todo)=>{
            this.todos=todo;
          }
      })
    }
   
   }

   
  
}
