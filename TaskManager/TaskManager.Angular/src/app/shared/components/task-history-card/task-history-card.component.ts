import { Component,Input, OnInit } from '@angular/core';
import { TaskHistory } from '../../models/taskHistory';

@Component({
  selector: 'app-task-history-card',
  templateUrl: './task-history-card.component.html',
  styleUrls: ['./task-history-card.component.css']
})
export class TaskHistoryCardComponent implements OnInit {
  @Input() taskHistory:TaskHistory | undefined;
  constructor() { }

  ngOnInit(): void {
  }

}
