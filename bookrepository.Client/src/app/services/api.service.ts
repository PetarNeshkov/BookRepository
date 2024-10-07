import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';

import {Observable, throwError} from 'rxjs';
import {catchError} from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ApiService
{
  constructor (private http : HttpClient)
  {
  }

  get (path : string, params ?: HttpParams) : Observable<any>
  {
    return this.http
      .get(`${ path }`, {params: params})
      .pipe(catchError(this.formatErrors));
  }

  patch (path : string, body : Object = {}) : Observable<any>
  {
    return this.http
      .patch(`${ path }`, body)
      .pipe(catchError(this.formatErrors));
  }

  post (path : string, body : Object = {}) : Observable<any>
  {
    return this.http
      .post(`${ path }`, body)
      .pipe(catchError(this.formatErrors));
  }

  delete (path : string, params ?: URLSearchParams) : Observable<any>
  {
    return params
      ? this.http
        .delete(`${ path }?${ params.toString() }`)
        .pipe(catchError(this.formatErrors))
      : this.http
        .delete(path)
        .pipe(catchError(this.formatErrors));
  }

  private formatErrors (error : any) : Observable<never>
  {
    return throwError(() => error.error);
  }
}
