import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskHistoryService } from '../core/services/task-history.service';
import { TaskHistory } from '../shared/models/taskHistory';

@Component({
  selector: 'app-task-history',
  templateUrl: './task-history.component.html',
  styleUrls: ['./task-history.component.css']
})
export class TaskHistoryComponent implements OnInit {
  taskHistories:TaskHistory[];
  userId : number | undefined;
  constructor(private taskHistoryService:TaskHistoryService, private route : ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      p=> {
        this.userId = +p.get('id');   // '+' will convert string into number. we get the id from the URL.
        console.log(this.userId);
        
        //make a call to movie service to get movie details
        this.taskHistoryService.getTaskHistoryForUser(this.userId).subscribe(
          t=> {
            this.taskHistories = t;
            console.log(this.taskHistories);
          }
        );
      }
      
    ) 
    
  }

}
