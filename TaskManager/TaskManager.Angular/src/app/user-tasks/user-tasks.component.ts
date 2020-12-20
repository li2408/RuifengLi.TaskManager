import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../core/services/task.service';
import { Task } from '../shared/models/task';
import { User } from '../shared/models/user';

@Component({
  selector: 'app-user-tasks',
  templateUrl: './user-tasks.component.html',
  styleUrls: ['./user-tasks.component.css']
})
export class UserTasksComponent implements OnInit {

  constructor(private route : ActivatedRoute, private taskService:TaskService) { }
  user:User | undefined;
  userId:number | undefined;
  tasks:Task[] | undefined;
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      p=> {
      this.userId = +p.get('id');   // '+' will convert string into number. we get the id from the URL.
        console.log(this.userId);
        
        //make a call to movie service to get movie details
        this.taskService.getUserTasks(this.userId).subscribe(
          t=> {
            this.tasks = t;
            console.log(this.tasks);
          }
        );
      }
    )
    
  }

}
