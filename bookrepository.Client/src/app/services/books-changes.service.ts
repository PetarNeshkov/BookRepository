import {Injectable} from '@angular/core';
import * as RouteConstants from '../constants/route.constants';
import {ApiService} from './api.service';
import {HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IBooksChangesModel} from '../models/BooksChanges';

@Injectable({
  providedIn: 'root'
})
export class BooksChangesService
{
  private routeConstants = RouteConstants.BOOK_CHANGES_URLS;

  constructor (private api : ApiService) { }

  getBooksChangesByPage (page : number = 1) : Observable<IBooksChangesModel>
  {
    let params = new HttpParams().set('page', page.toString());

    return this.api
      .get(this.routeConstants.ALL_BOOK_HISTORIES,
        params);
  }
}
