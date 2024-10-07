import {Injectable} from '@angular/core';
import * as RouteConstants from '../constants/route.constants';
import {ApiService} from './api.service';
import {IAuthor, IAuthorsModel, IAuthorsNamesModel, IAuthorUrlParams} from '../models/Authors';
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

  loadAuthorData (authorId : number) : Observable<IAuthor>
  {
    let params = new HttpParams().set('authorId', authorId.toString());

    return this.api.get(this.routeConstants.GETAUTHORDATA, params).pipe(
      catchError((error : HttpErrorResponse) =>
      {
        return throwError(() => error);
      })
    );
  }

  getAuthorsByPage (page : number = 1) : Observable<IAuthorsModel>
  {
    let params = new HttpParams().set('page', page.toString());

    return this.api
      .get(this.routeConstants.ALL_AUTHORSBYPAGE,
        params);
  }

  getAuthorsNames () : Observable<IAuthorsNamesModel>
  {
    return this.api
      .get(this.routeConstants.GETAUTHORSNAMES);
  }

  updateAuthor (author : IAuthor) : Observable<IAuthor>
  {
    return this.api.patch(this.routeConstants.UPDATE_AUTHOR, author).pipe(
      catchError((error : HttpErrorResponse) =>
      {
        return throwError(() => error);
      })
    );
  }

}
