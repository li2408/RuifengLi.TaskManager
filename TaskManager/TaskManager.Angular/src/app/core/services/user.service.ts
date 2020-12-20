import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/shared/models/user';
import { ObserveOnSubscriber } from 'rxjs/internal/operators/observeOn';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService) { }
  getAllUsers():Observable<User[]> {
    return this.apiService.getAll('Users/allusers');
  }
}
