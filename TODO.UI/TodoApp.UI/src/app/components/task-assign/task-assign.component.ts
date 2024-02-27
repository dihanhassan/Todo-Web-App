import { Component, Inject, OnInit } from '@angular/core';
import { Todo } from '../../models/todo.model';
import { TodoService } from '../../services/todo.service';
import { DialogRef } from '@angular/cdk/dialog';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { warn } from 'console';

@Component({
  selector: 'app-task-assign',
  templateUrl: './task-assign.component.html',
  styleUrl: './task-assign.component.css'
})
export class TaskAssignComponent  implements OnInit{
  todos: Todo[] = [];
  newTodo: Todo = {
    taskId:0,
    id: 0,
    title: '',
    descriptions: '',
    isCompleted: 0,
    createdOn: new Date(),
    dueDate: new Date(),
    prioritys: ''
  };
  constructor
  (
    private _dialog : MatDialog,
    private todoService: TodoService ,
    private _dialogRef : MatDialogRef<TaskAssignComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    
  ) 
  {

    this.newTodo=data.todo;
    this.newTodo.taskId=data.todo.taskId;
    
  }
  ngOnInit(): void {
    this.getAllTodos();
   
    
  }
  getAllTodos() {
    this.todoService.getAllTodos(this.newTodo.id)
      .subscribe({
        next: (todos) => {
          this.todos = todos;
          
        }
      });
  }

  onClose() {
    
  }

}





