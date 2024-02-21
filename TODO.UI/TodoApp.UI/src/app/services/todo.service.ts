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

  getAllTodos(): Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodos')
               .pipe(map((response: { listTodos: any; }) => response.listTodos));
  }
  addTodo(newTodo: Todo): Observable<Todo>{
    
    newTodo.id =0;
    return this.http.post<Todo>(this.baseApiUrl + '/api/Todo/AddTodo', newTodo);
  }

  deleteTodo(id : number) : Observable<Todo>{
    alert("Todo deleted");
    return this.http.delete<Todo>(this.baseApiUrl + '/api/Todo/DeleteTodo/'+id)
  }
  updateTodo(newTodo: Todo): Observable<Todo>{
    console.log(newTodo)
    return this.http.put<Todo>(this.baseApiUrl + '/api/Todo/UpdateTodo', newTodo);
   
  }

  getAllTodosUsingFilter(filterOption:string): Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodosUsingFilter/'+filterOption)
               .pipe(map((response: { listTodos: any; }) => response.listTodos));
  }

  statusUpdateTodo(newTodo: Todo): Observable<Todo>{
    console.log(newTodo)
    return this.http.patch<Todo>(this.baseApiUrl + '/api/Todo/StatusUpdateTodo', newTodo);
   
  }

  searchInTodo(searchText : string) : Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodosUsingSearch/'+searchText)
    .pipe(map((response: {listTodos: any;})=>response.listTodos
    
    ));
  }

  userValidition(login: Login): Observable<Login> {
    
    return this.http.post<any>(this.baseApiUrl + '/api/Todo/UserValidition', login)
    .pipe(
      map(response => response.login) // Map to the 'login' property
    );
     
  }
  GetAllTodosUsingStatus(filterOption:number): Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodosUsingStatus/'+filterOption)
               .pipe(map((response: { listTodos: any; }) => response.listTodos));
  }


  

}
