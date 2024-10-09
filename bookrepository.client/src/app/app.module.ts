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
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AuthorsService} from './services/authors.service';

import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MAT_DATE_LOCALE, MatNativeDateModule} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatOptionModule} from '@angular/material/core';
import {BooksService} from './services/books.service';

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
    FormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatOptionModule
  ],
  providers: [
    AuthorsService,
    BooksService,
    {provide: MAT_DATE_LOCALE, useValue: 'en-GB'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
