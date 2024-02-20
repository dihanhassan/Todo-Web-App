import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TodosComponent } from './components/todos/todos.component';
import { AppComponent } from './app.component';
import { LogInComponent } from './components/log-in/log-in.component';




const routes: Routes = [
  {
    path: '',
    component: LogInComponent
  },
  {
    path: 'login',
    component: LogInComponent
  },
 
  {
    path: 'todos',
    component: TodosComponent
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
