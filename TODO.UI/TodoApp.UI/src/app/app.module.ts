import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TodosComponent } from './components/todos/todos.component';
import { FormsModule } from '@angular/forms';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatDialogModule} from '@angular/material/dialog';
import { AddtodoComponent } from './components/addtodo/addtodo.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSelectModule} from '@angular/material/select';
import { EditTodoComponent } from './components/edit-todo/edit-todo.component';
import {MatCardModule} from '@angular/material/card';
import {FormControl, ReactiveFormsModule} from '@angular/forms';


import {FormBuilder} from '@angular/forms';
import {JsonPipe} from '@angular/common';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { LogInComponent } from './components/log-in/log-in.component';
import { TaskAssignComponent } from './components/task-assign/task-assign.component';



@NgModule({
  declarations: [
    AppComponent,
    TodosComponent,
    AddtodoComponent,
    EditTodoComponent,
    LogInComponent,
    TaskAssignComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInput,
    MatDatepickerModule,
    BrowserAnimationsModule,
    MatNativeDateModule,
    MatSelectModule,
   
    ReactiveFormsModule,
    
    JsonPipe,
    MatCheckboxModule,
    MatCardModule,
    
   

  ],

  
  providers: [
    provideClientHydration(),
    provideAnimationsAsync(),

    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
