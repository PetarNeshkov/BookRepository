import {Injectable} from '@angular/core';
import * as RouteConstants from '../constants/route.constants';
import {ApiService} from './api.service';
import {IBookUrlParams, IEditBookUrlParams} from '../models/Books';
import {HttpErrorResponse, HttpParams} from '@angular/common/http';
import {Observable, catchError, throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService
{
  private routeConstants = RouteConstants.BOOK_URLS;

  constructor (private api : ApiService) { }

  createBook (book : IEditBookUrlParams) : Observable<IEditBookUrlParams>
  {
    return this.api.post(this.routeConstants.CREATE_BOOK, book).pipe(
      catchError((error : HttpErrorResponse) =>
      {
        return throwError(() => error);
      })
    );
  }

  updateBook(book: IBookUrlParams) : Observable<IBookUrlParams>{
    return this.api.patch(this.routeConstants.UPDATE_BOOK, book).pipe(
      catchError((error : HttpErrorResponse) =>
      {
        return throwError(() => error);
      })
    );
  }

  loadBookData (bookId : number) : Observable<IBookUrlParams>
  {
    let params = new HttpParams().set('bookId', bookId.toString());

    return this.api.get(this.routeConstants.GETBOOKATA, params).pipe(
      catchError((error : HttpErrorResponse) =>
      {
        return throwError(() => error);
      })
    );
  }
}
