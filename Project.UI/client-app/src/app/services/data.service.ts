import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/observable/throw';
import { NotFoundError } from "../common/not-found-error";
import { BadRequestError } from "../common/bad-request-error";
import { AppError } from "../common/app-error";

@Injectable()
export class DataService {
  url: string;
  
  constructor(private relatedUrl: string, private http: HttpClient) { 
    this.url = "http://10.211.55.3:7777/api" + this.relatedUrl;
  }

  getAll<T>() {
    return this.http.get<T>(this.url)
      .catch(this.handleError);
  }

  get<T>(id) { 
    return this.http.get<T>(this.url + '/' + id)
      .catch(this.handleError);    
  }

  create<T>(resource) {
    return this.http.post<T>(this.url, JSON.stringify(resource))
      .catch(this.handleError);
  }

  update<T>(resource) {
    return this.http.put<T>(this.url + '/' + resource.id, JSON.stringify({ isRead: true }))   
      .catch(this.handleError);
  }

  delete<T>(id) {
    return this.http.delete<T>(this.url + '/' + id)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
     if (error.status === 400)
       return Observable.throw(new BadRequestError(error));
  
     if (error.status === 404)
       return Observable.throw(new NotFoundError(error));
    
     return Observable.throw(new AppError(error));
  } 
}
