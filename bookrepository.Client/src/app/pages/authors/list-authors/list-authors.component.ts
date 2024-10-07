import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthorsService} from '../../../services/authors.service';
import {IAuthor, IAuthorsModel} from '../../../models/Authors';

@Component({
  selector: 'app-list-authors',
  templateUrl: './list-authors.component.html',
  styleUrl: './list-authors.component.css'
})
export class ListAuthorsComponent implements OnInit
{
  successMessage : string | null = null;
  authors : IAuthor[] = [];
  itemsPerPage : number = 5;
  currentPage : number = 1;
  totalAuthorsCount : number = 0;
  displayedColumns : string[] = ['name', 'bio', 'edit'];

  constructor (private authorsService : AuthorsService, private router : Router) { }

  ngOnInit () : void
  {
    this.successMessage = history.state.successMessage;

    if (this.successMessage) {
      setTimeout(() =>
      {
        this.successMessage = null;
      }, 5000);
    }

    this.loadAuthors();
  }

  loadAuthors () : void
  {
    this.authorsService.getAuthorsByPage(this.currentPage).subscribe((response : IAuthorsModel) =>
    {
      this.authors = response.authors;
      this.totalAuthorsCount = response.authorsTotalCount;
    });
  }

  onPageChange (event : any) : void
  {
    this.itemsPerPage = event.pageSize;
    this.currentPage = event.pageIndex + 1;
    this.loadAuthors();
  }

  editAuthor (authorId : number) : void
  {
    this.router.navigate(['authors/manage', authorId]);
  }
}
