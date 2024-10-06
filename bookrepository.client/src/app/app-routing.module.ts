import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ListBooksComponent} from './pages/books/list-books/list-books.component';
import {ManageBookComponent} from './pages/books/manage-book/manage-book.component';
import {ListAuthorsComponent} from './pages/authors/list-authors/list-authors.component';
import {ManageAuthorComponent} from './pages/authors/manage-author/manage-author.component';
import {BookHistoryComponent} from './pages/books/book-history/book-history.component';
import {NotFoundComponent} from './pages/not-found/not-found.component';

const routes : Routes = [
  {path: '', redirectTo: 'books/list', pathMatch: 'full'}, // Redirect root to list-books
  {path: 'home', redirectTo: 'books/list', pathMatch: 'full'}, // Redirect /home to list-books
  {
    path: 'authors', children: [
      {path: 'list', component: ListAuthorsComponent},
      {path: 'manage', component: ManageAuthorComponent},
    ]
  },
  {
    path: 'books', children: [
      {path: 'list', component: ListBooksComponent}, // Main page for books listing
      {path: 'manage', component: ManageBookComponent},
    ]
  },
  {path: 'book-history', component: BookHistoryComponent},
  {path: '**', component: NotFoundComponent} // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
