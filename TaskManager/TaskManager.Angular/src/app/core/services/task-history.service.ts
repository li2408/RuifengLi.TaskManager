import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class TaskHistoryService {

  constructor(private apiService: ApiService) { 

  }
  getTaskHistoryForUser(id:number):Observable<any> {
    return this.apiService.getAll('TaskHistory',id);
  }
}
