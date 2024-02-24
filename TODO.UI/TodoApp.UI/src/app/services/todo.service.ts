import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Todo } from '../models/todo.model';
import { response } from 'express';
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseApiUrl: string ="https://localhost:7131";
   
  constructor(private http: HttpClient) { }

  getAllTodos(id : number): Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodos/'+id)
               .pipe(map((response: { listTodos: any; }) => response.listTodos));
  }
  addTodo(newTodo: Todo): Observable<Todo>{
    
   
    return this.http.post<Todo>(this.baseApiUrl + '/api/Todo/AddTodo', newTodo);
  }

  deleteTodo(id : number, task_id:number) : Observable<Todo>{
    alert("Todo deleted" + task_id);
    
    return this.http.delete<Todo>(this.baseApiUrl + '/api/Todo/DeleteTodo/'+id + '/' + task_id )
  }
  updateTodo(newTodo: Todo): Observable<Todo>{
    console.log(newTodo)
    return this.http.put<Todo>(this.baseApiUrl + '/api/Todo/UpdateTodo', newTodo);
   
  }

  getAllTodosUsingFilter(filterOption:string,user_id:number): Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodosUsingFilter/' + filterOption + '/' + user_id)
               .pipe(map((response: { listTodos: any; }) => response.listTodos));
  }

  statusUpdateTodo(newTodo: Todo): Observable<Todo>{
    console.log(newTodo)
    return this.http.patch<Todo>(this.baseApiUrl + '/api/Todo/StatusUpdateTodo', newTodo);
   
  }

  searchInTodo(searchText : string,id : number) : Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodosUsingSearch/'+searchText+'/'+id)
    .pipe(map((response: {listTodos: any;})=>response.listTodos
    
    ));
  }

  userValidition(login: Login): Observable<Login> {
    
    return this.http.post<any>(this.baseApiUrl + '/api/Auth/UserValidition', login)
    .pipe(
      map(response => response.login) // Map to the 'login' property
    );
     
  }
  GetAllTodosUsingStatus(filterOption:number,id :number): Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodosUsingStatus/'+filterOption+'/'+id)
               .pipe(map((response: { listTodos: any; }) => response.listTodos));
  }


  

}
