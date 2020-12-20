import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { TasksComponent } from './tasks/tasks.component';
import { UsersComponent } from './users/users.component';
import { UserCardComponent } from './shared/components/user-card/user-card.component';
import { UserTasksComponent } from './user-tasks/user-tasks.component';
import {ReactiveFormsModule, FormsModule} from '@angular/forms';
import { UserTaskCardComponent } from './shared/components/user-task-card/user-task-card.component';
import { TaskHistoryCardComponent } from './shared/components/task-history-card/task-history-card.component';
import { TaskHistoryComponent } from './task-history/task-history.component';
import { AddTaskComponent } from './add-task/add-task.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    TasksComponent,
    UsersComponent,
    UserCardComponent,
    UserTasksComponent,
    UserTaskCardComponent,
    TaskHistoryCardComponent,
    TaskHistoryComponent,
    AddTaskComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
