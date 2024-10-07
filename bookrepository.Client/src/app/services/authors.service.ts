import {Injectable} from '@angular/core';
import * as RouteConstants from '../constants/route.constants';
import {ApiService} from './api.service';
import {IAuthorsModel, IAuthorUrlParams} from '../models/Authors';
import {catchError, Observable, throwError} from 'rxjs';
import {HttpErrorResponse, HttpParams} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AuthorsService
{
  private routeConstants = RouteConstants.AUTHOR_URLS;

  constructor (private api : ApiService) { }

  createAuthor (author : IAuthorUrlParams) : Observable<any>
  {
    return this.api.post(this.routeConstants.CREATE_AUTHOR, author).pipe(
      catchError((error : HttpErrorResponse) =>
      {
        return throwError(() => error);
      })
    );
  }

  getAuthors (page : number = 1) : Observable<IAuthorsModel>
  {
    let params = new HttpParams().set('page', page.toString());

    return this.api
      .get(this.routeConstants.ALL_AUTHORS,
        params);
  }
}
