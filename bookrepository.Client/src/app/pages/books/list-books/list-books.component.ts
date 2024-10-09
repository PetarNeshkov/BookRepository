import {Component, OnInit} from '@angular/core';
import {BooksService} from '../../../services/books.service';
import {IBook, IBooksModel, IBookUrlParams, IFilterParams} from '../../../models/Books';
import {Router} from '@angular/router';
import {Subject} from 'rxjs/internal/Subject';
import {debounceTime} from 'rxjs';

@Component({
  selector: 'app-list-books',
  templateUrl: './list-books.component.html',
  styleUrls: ['./list-books.component.css']
})
export class ListBooksComponent implements OnInit
{
  successMessage : string | null = null;
  books : IBookUrlParams[] = [];
  itemsPerPage : number = 5;
  totalBooksCount : number = 0;
  displayedColumns : string[] = ['title', 'description', 'authors', 'publishDate', 'actions'];
  filterParams : IFilterParams = {
    query: '',
    byTitle: false,
    byAuthor: false,
    sortDirection: 'asc',
    page: 1,
  };

  private filterSubject : Subject<void> = new Subject();

  constructor (private booksService : BooksService, private router : Router) { }

  ngOnInit () : void
  {
    this.successMessage = history.state.successMessage;

    this.filterSubject.pipe(debounceTime(500)).subscribe(() =>
    {
      if (this.filterParams.byTitle || this.filterParams.byAuthor) {
        this.filterParams.page = 1;

        this.getCurrentBooks();
        this.router.navigateByUrl(this.router.url, {state: {}});
      }
    });

    if (this.successMessage) {
      setTimeout(() =>
      {
        this.successMessage = null;
        this.router.navigateByUrl(this.router.url, {state: {}});
      }, 5000);
    }

    this.getCurrentBooks();
  }

  getCurrentBooks () : void
  {
    this.booksService.getCurrentBooks(this.filterParams).subscribe((response : IBooksModel) =>
    {
      this.books = response.books;
      this.totalBooksCount = response.booksTotalCount;
    });
  }

  onPageChange (event : any) : void
  {
    this.filterParams.page = event.pageIndex + 1;
    this.getCurrentBooks();
  }

  editBook (book : IBook) : void
  {
    this.router.navigate(['books/manage', book.id], {state: {book: book}});
  }

  deleteBook (bookId : number) : void
  {
    this.booksService.deleteBook(bookId).subscribe({
      next: (response : string) =>
      {
        this.successMessage = response;

        setTimeout(() =>
        {
          this.successMessage = null;
          this.router.navigateByUrl(this.router.url, {state: {}});
        }, 5000);

        this.getCurrentBooks();
      },
      error: () =>
      {
        this.router.navigate(['/notFound']);
      }
    });
  }

  onFilterChange () : void
  {
    this.filterSubject.next();
  }

  onSortChange () : void
  {
    this.getCurrentBooks();
  }
}
