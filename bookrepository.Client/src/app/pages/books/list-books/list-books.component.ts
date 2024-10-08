import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-list-books',
  templateUrl: './list-books.component.html',
  styleUrl: './list-books.component.css'
})
export class ListBooksComponent implements OnInit
{
  successMessage : string | null = null;

  constructor (private router : Router) { }

  ngOnInit () : void
  {
    this.successMessage = history.state.successMessage;

    if (this.successMessage) {
      setTimeout(() =>
      {
        this.successMessage = null;
      }, 5000);
    }

  }
}
