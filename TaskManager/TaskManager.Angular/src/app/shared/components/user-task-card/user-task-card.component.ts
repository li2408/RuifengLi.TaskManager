import { Component,Input, OnInit } from '@angular/core';
import { TaskService } from 'src/app/core/services/task.service';
import { Task } from '../../models/task';
import { TaskHistory } from '../../models/taskHistory';

@Component({
  selector: 'app-user-task-card',
  templateUrl: './user-task-card.component.html',
  styleUrls: ['./user-task-card.component.css']
})
export class UserTaskCardComponent implements OnInit {
  @Input()
  task!: Task;

  //create a task history:
  taskHistory : TaskHistory = {
    userId : 0,
    title : '',
    description : '',
    dueDate : new Date(),
    completed : new Date(),
    remarks: ''
  };
  
  constructor(
    private taskService:TaskService) 
    {
    
    }

  ngOnInit(): void {
    
  }
  
  //logic:
  //step1: move this task to history table.
  //step2: remove this task from task table.
  moveCardToHistory() {
    this.taskHistory.userId = this.task.userId;
    this.taskHistory.title = this.task.title;
    this.taskHistory.description = this.task.description;
    this.taskHistory.dueDate = this.task.dueDate;
    this.taskHistory.completed = new Date();
    this.taskHistory.remarks = this.task.remarks;

    //step1: move this task to history table.
    this.taskService.moveTaskToHistory(this.taskHistory).subscribe(
      (response) => {
        if(response!=null) {
          console.log(this.taskHistory);
        }else {
          console.log('move to history failed');
          console.log(this.task);
        }
      }
    );

    //step2: remove this task from task table.
    this.taskService.removeTaskFromTable(this.task).subscribe (
      (response) => {
        if(response!=null) {
          location.reload();
        }else {
          console.log('removal failed');
        }
      }
    )
  }
  

}
