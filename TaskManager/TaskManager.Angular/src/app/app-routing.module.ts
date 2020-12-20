import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { Routes, RouterModule } from '@angular/router';
import { UserTasksComponent } from './user-tasks/user-tasks.component';
import { TaskHistoryComponent } from './task-history/task-history.component';
import { AddTaskComponent } from './add-task/add-task.component';


const routes: Routes = [

  {
    path: "",
    component:HomeComponent,
  },
  
  {
    path: "tasks/:id",
    component:UserTasksComponent,
  },

  {
    path: "tasks/taskshistory/:id",
    component:TaskHistoryComponent,
  },

  {
    path: "tasks/addtask/:id",
    component:AddTaskComponent,
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
