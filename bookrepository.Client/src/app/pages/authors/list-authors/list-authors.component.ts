import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-authors',
  templateUrl: './list-authors.component.html',
  styleUrl: './list-authors.component.css'
})
export class ListAuthorsComponent implements OnInit {
  successMessage : string | null = null;

  constructor (private route : ActivatedRoute) { }

  ngOnInit () : void
  {
    this.route.queryParams.subscribe((params) =>
    {
      this.successMessage = params['successMessage'] || null;

      if (this.successMessage) {
        setTimeout(() =>
        {
          this.successMessage = null;
        }, 5000);
      }
    });
  }
}
