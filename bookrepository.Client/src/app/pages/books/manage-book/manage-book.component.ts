import {Component, OnInit} from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import {Router, ActivatedRoute} from '@angular/router';
import {IAuthor, IAuthorName} from '../../../models/Authors';
import {AuthorsService} from '../../../services/authors.service';
import {BooksService} from '../../../services/books.service';
import {IBookUrlParams, IEditBookUrlParams} from '../../../models/Books';
import {ValidationError} from '../../../models/ValidationError';
import {MatSelectChange} from '@angular/material/select';

@Component({
  selector: 'app-manage-book',
  templateUrl: './manage-book.component.html',
  styleUrl: './manage-book.component.css'
})
export class ManageBookComponent implements OnInit
{
  bookForm! : FormGroup;
  errorMessage : {[key : string] : string;} = {};
  authorsList : IAuthorName[] = [];
  bookId : number | null = null;
  title : string = 'Create a Book';

  constructor (
    private fb : FormBuilder,
    private authorsService : AuthorsService,
    private booksService : BooksService,
    private router : Router,
    private route : ActivatedRoute
  ) { }

  ngOnInit () : void
  {
    this.createForm();
    this.loadAuthors();

    this.route.paramMap.subscribe((params) =>
    {
      const bookId = params.get('id') ? +params.get('id')! : null;

      if (bookId) {
        this.loadBookData(bookId);
        this.title = 'Edit a Book';
      }
    });
  }

  createForm ()
  {
    this.bookForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', [Validators.required, Validators.maxLength(500)]],
      publishDate: ['', Validators.required],
      authors: [[], [Validators.required, this.maxAuthorsSelected(3)]],
    });
  }

  maxAuthorsSelected (max : number)
  {
    return (control : any) =>
    {
      const selectedAuthors = control.value || [];
      if (selectedAuthors.length > max) {
        return {maxAuthors: true};
      }
      return null;
    };
  }

  authorSelectionChange (event : any)
  {
    const selectedAuthors = this.bookForm.get('authors')?.value || [];
    if (selectedAuthors.length > 3) {
      this.bookForm.get('authors')?.setErrors({maxAuthors: true});
    } else {
      this.bookForm.get('authors')?.setErrors(null);
    }
  }

  loadAuthors ()
  {
    this.authorsService.getAuthorsNames().subscribe((response : IAuthorName[]) =>
    {
      this.authorsList = response;
    });
  }

  loadBookData (id : number) : void
  {
    this.booksService.loadBookData(id).subscribe({
      next: (response) =>
      {
        this.bookForm.patchValue({
          title: response.title,
          description: response.description,
          publishDate: response.publishDate,
          authors: response.authors.map((a) => a.name),
        });
      },
      error: () =>
      {
        this.router.navigate(['/notFound']);
      },
    });
  }

  get f ()
  {
    return this.bookForm.controls;
  }

  onSubmit ()
  {
    if (this.bookForm.invalid) {
      return;
    }

    this.errorMessage = {};
    const bookData = this.getBookFormData();

    this.submitBookData(bookData);
  }

  private getBookFormData () : IEditBookUrlParams
  {
    return {
      title: this.f['title'].value,
      description: this.f['description'].value,
      publishDate: this.f['publishDate'].value,
      authors: this.f['authors'].value,
      originalTitle: this.f['originalTitle'].value,
      originalDescription: this.f['originalDescription'].value
    };
  }

  private submitBookData (bookData : IEditBookUrlParams) : void
  {
    if (this.bookId) {
      const request : IEditBookUrlParams = {
        id: this.bookId,
        title: bookData.title,
        description: bookData.description,
        publishDate: bookData.publishDate,
        authors: bookData.authors,
        originalTitle: bookData.originalTitle,
        originalDescription: bookData.originalDescription,
      };

      this.booksService.updateBook(request).subscribe({
        next: (response) => this.handleSuccess(response),
        error: (errors : ValidationError[]) => this.handleErrors(errors),
      });
    } else {
      this.booksService.createBook(bookData).subscribe({
        next: (response) => this.handleSuccess(response),
        error: (errors : ValidationError[]) => this.handleErrors(errors),
      });
    }
  }

  private handleSuccess (response : any) : void
  {
    this.router.navigate(['/books/list'], {
      state: {successMessage: response}
    });
  }

  private handleErrors (errors : ValidationError[]) : void
  {
    errors.forEach(err =>
    {
      this.errorMessage[err.propertyName] = err.errorMessage;
      this.bookForm.get(err.propertyName)?.setErrors({custom: true});
    });
  }
}

