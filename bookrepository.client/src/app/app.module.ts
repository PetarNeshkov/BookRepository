import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ManageAuthorComponent} from './pages/authors/manage-author/manage-author.component';
import {ListAuthorsComponent} from './pages/authors/list-authors/list-authors.component';
import {ManageBookComponent} from './pages/books/manage-book/manage-book.component';
import {ListBooksComponent} from './pages/books/list-books/list-books.component';
import {BookHistoryComponent} from './pages/book-history/book-history.component';
import {NotFoundComponent} from './pages/not-found/not-found.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthorsService } from './services/authors.service';

@NgModule({
  declarations: [
    AppComponent,
    ManageAuthorComponent,
    ListAuthorsComponent,
    ManageBookComponent,
    ListBooksComponent,
    BookHistoryComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule
  ],
  providers: [AuthorsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
