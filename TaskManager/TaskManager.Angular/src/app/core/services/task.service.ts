import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Task } from 'src/app/shared/models/task';
import { TaskHistory } from 'src/app/shared/models/taskHistory';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private apiService: ApiService) { }
  getUserTasks(id:number):Observable<Task[]> {
    return this.apiService.getAll('Tasks',id); //get the task based on user's id.
  }

  moveTaskToHistory(taskHistory:TaskHistory):Observable<any> {
    console.log(taskHistory);
    return this.apiService.create('TaskHistory/addtaskhistory', taskHistory);
  }

  removeTaskFromTable(task:Task):Observable<any>{
    return this.apiService.delete('Tasks/deleteTask',task);
  }

  addTask(task:Task):Observable<any> {
    return this.apiService.create('Tasks/addTask',task);
  }

}
