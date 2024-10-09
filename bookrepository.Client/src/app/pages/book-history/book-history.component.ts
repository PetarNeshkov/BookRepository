import {Component, OnInit} from '@angular/core';
import {IBooksChanges, IBooksChangesModel} from '../../models/BooksChanges';
import {PageEvent} from '@angular/material/paginator';
import {BooksChangesService} from '../../services/books-changes.service';

@Component({
  selector: 'app-book-history',
  templateUrl: './book-history.component.html',
  styleUrl: './book-history.component.css'
})
export class BookHistoryComponent implements OnInit
{
  bookChanges : IBooksChanges[] = [];
  itemsPerPage : number = 5;
  currentPage : number = 1;
  totalBookChangesCount : number = 0;
  displayedColumns : string[] = ['changeTime', 'changeDescription'];

  constructor (private bookChangesService : BooksChangesService) { }


  ngOnInit () : void
  {
    this.loadBookChanges();
  }

  loadBookChanges () : void
  {
    this.bookChangesService.getBooksChangesByPage(this.currentPage).subscribe((response : IBooksChangesModel) =>
    {
      this.bookChanges = response.booksChanges;
      this.totalBookChangesCount = response.booksChangesTotalCount;
    });
  }

  onPageChange (event : PageEvent) : void
  {
    this.itemsPerPage = event.pageSize;
    this.currentPage = event.pageIndex + 1;
    this.loadBookChanges();
  }
}
