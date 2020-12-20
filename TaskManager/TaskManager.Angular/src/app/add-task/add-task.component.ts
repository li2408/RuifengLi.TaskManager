import { Component, OnInit } from '@angular/core';
import { TaskService } from '../core/services/task.service';
import { Task } from '../shared/models/task';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {
 
  constructor( private route : ActivatedRoute,  private taskService:TaskService, private router: Router) { }
  task : Task = {
    id : 0,
    userId : +1,
    title : '',
    description : '',
    dueDate : null,
    priority : null,
    remarks : ''

  };
  userId : number | undefined;
  returnUrl: any;
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      p=> {
        this.userId = +p.get('id');   // '+' will convert string into number. we get the id from the URL.
        console.log(this.userId);
      }
      
    ).add(this.route.queryParams.subscribe(
      (params) => (this.returnUrl = params.returnUrl || '/')
    )
    ) 
  }
  //method to add a task for this user.

  addTask() {
    this.task.userId= this.userId;
    console.log(this.task.userId);
    this.taskService.addTask(this.task).subscribe(
      t=> {
        console.log(this.task);
        this.router.navigate([this.returnUrl]); 
      }
    )
  }
}
