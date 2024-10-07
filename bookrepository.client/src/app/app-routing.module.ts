import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ListBooksComponent} from './pages/books/list-books/list-books.component';
import {ManageBookComponent} from './pages/books/manage-book/manage-book.component';
import {ListAuthorsComponent} from './pages/authors/list-authors/list-authors.component';
import {BookHistoryComponent} from './pages/book-history/book-history.component';
import {NotFoundComponent} from './pages/not-found/not-found.component';
import { ManageAuthorComponent } from './pages/authors/manage-author/manage-author.component';

const routes : Routes = [
  {path: '', redirectTo: 'books/list', pathMatch: 'full'}, 
  {path: 'home', redirectTo: 'books/list', pathMatch: 'full'},
  {
    path: 'authors', children: [
      {path: 'list', component: ListAuthorsComponent},
      {path: 'manage', component: ManageAuthorComponent},
      {path: 'manage/:id', component: ManageAuthorComponent},
    ]
  },
  {
    path: 'books', children: [
      {path: 'list', component: ListBooksComponent}, 
      {path: 'manage', component: ManageBookComponent},
      {path: 'manage/:id', component: ManageBookComponent},
    ]
  },
  {path: 'book-history', component: BookHistoryComponent},
  {path: '**', component: NotFoundComponent} 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
