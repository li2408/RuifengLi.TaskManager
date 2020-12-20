import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {map} from 'rxjs/operators';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams} from "@angular/common/http";
import { TasksComponent } from 'src/app/tasks/tasks.component';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private headers: HttpHeaders; // to create a HttpHeader.
  constructor(protected http:HttpClient) { 
    this.headers = new HttpHeaders();
    this.headers.append('Content-type','application/json'); //create a HttpHeader key value pair.
  } //gonna make AJAX HTTP call to the API.
  
  getAll(path:string, id?:number):Observable<any[]> { //Observable<any[]> is the return type
    let getUrl:string;
    if(id) {
      getUrl = `${environment.apiUrl}${path}` + '/' + id;
    }else {
      getUrl = `${environment.apiUrl}${path}`;
    }
    return this.http.get(getUrl).pipe(
      map(resp=> resp as any) // map is like 'select' in LINQ
      //create anomunous objects.
      //I know my response is going to be an array of JSON objects, so just map it to be a anomynous type. but why anomynous array?
      //"any" means: can pass in any type of object in it.
    )
  }
  // employess.select(emp => new {id = emp.id,name = emp.firstname + emp.lastname})
  // new: create a new anomunous object.

  getOne(path:string, id?:number):Observable<any> { //getById
    let getUrl:string;
    if(id) {
      getUrl = `${environment.apiUrl}${path}` + '/' + id;
    }else {
      getUrl = `${environment.apiUrl}${path}`;
    }
    
    return this.http.get(getUrl).pipe(
      map(resp=> resp as any)
    )
  }

  //POST method:
  create(path:string, resource:any ,options?:any):Observable<any> {//? means we don't need to pass this parameter
    //resource is for the data we are posting. we are posting in form of JS, and angular is gonna convert it to JSON and send it 
    //to the API.
    return this.http
    .post(`${environment.apiUrl}${path}`,resource,{headers:this.headers})
    .pipe(map(response => response));
  }

  //DELETE method:
  delete(path:string, resource:any):Observable<any> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json',
      }),
      body : {
        id : resource.id,
        userId : resource.userId,
        title : resource.title,
        description: resource.description,
        dueDate : resource.dueDate,
        priority : resource.priority,
        remarks : resource.remarks
      },
    };
    return this.http.delete(`${environment.apiUrl}${path}`,options);
  }
}

