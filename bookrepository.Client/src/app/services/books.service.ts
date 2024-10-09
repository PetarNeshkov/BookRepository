import {Injectable} from '@angular/core';
import * as RouteConstants from '../constants/route.constants';
import {ApiService} from './api.service';
import {IBookUrlParams, IBook, IFilterParams} from '../models/Books';
import {HttpErrorResponse, HttpParams} from '@angular/common/http';
import {Observable, catchError, throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService
{
  private routeConstants = RouteConstants.BOOK_URLS;

  constructor (private api : ApiService) { }

  createBook (book : IBook) : Observable<IBook>
  {
    return this.api.post(this.routeConstants.CREATE_BOOK, book).pipe(
      catchError((error : HttpErrorResponse) =>
      {
        return throwError(() => error);
      })
    );
  }

  updateBook (book : IBook) : Observable<IBook>{
    return this.api.patch(this.routeConstants.UPDATE_BOOK, book).pipe(
      catchError((error : HttpErrorResponse) =>
      {
        return throwError(() => error);
      })
    );
  }

  deleteBook (bookId : number) : Observable<void>
  {
    let params = new URLSearchParams();
    params.append('bookId', bookId.toString());

    return this.api.delete(this.routeConstants.DELETE_BOOK, params).pipe(
      catchError((error : HttpErrorResponse) =>
      {
        return throwError(() => error);
      })
    );
  }

  getCurrentBooks (filterParams : IFilterParams)
  {
    let params = new HttpParams()
      .set('page', filterParams.page.toString())
      .set('sortDirection', filterParams.sortDirection)
      .set('query', filterParams.query);

    if (filterParams.byTitle) {
      params = params.set('filterByTitle', 'true');
    }

    if (filterParams.byAuthor) {
      params = params.set('filterByAuthor', 'true');
    }

    return this.api
      .get(this.routeConstants.ALLBOOKS,
        params);
  }


  loadBookData (bookId : number) : Observable<IBook>
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
