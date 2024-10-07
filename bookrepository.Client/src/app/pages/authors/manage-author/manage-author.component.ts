import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthorsService} from '../../../services/authors.service';
import {IAuthorUrlParams} from '../../../models/Authors';
import {Router} from '@angular/router';
import {ValidationError} from '../../../models/ValidationError';


@Component({
  selector: 'app-manage-author',
  templateUrl: './manage-author.component.html',
  styleUrls: ['./manage-author.component.css'],
})
export class ManageAuthorComponent implements OnInit
{
  authorForm! : FormGroup;
  errorMessage : {[key : string] : string;} = {};

  constructor (
    private fb : FormBuilder,
    private authorsService : AuthorsService,
    private router : Router
  ) { }

  ngOnInit () : void
  {
    this.createForm();
  }

  createForm ()
  {
    this.authorForm = this.fb.group({
      name: ['', [Validators.required]],
      bio: ['', [Validators.required]],
    });
  }

  get f ()
  {
    return this.authorForm.controls;
  }

  onSubmit ()
  {
    if (this.authorForm.invalid) {
      return;
    }

    this.errorMessage = {};

    const newAuthor : IAuthorUrlParams = {
      name: this.f['name'].value,
      bio: this.f['bio'].value,
    };

    this.authorsService.createAuthor(this.authorForm.value).subscribe({
      next: (response) =>
      {
        this.router.navigate(['/authors-listing'], {
          queryParams: {successMessage: `The ${ response } was successfully created.`}
        });
      },
      error: (errors : ValidationError[]) =>
      {
        errors.forEach(err =>
        {
          this.errorMessage[err.propertyName] = err.errorMessage;
          this.authorForm.get(err.propertyName)?.setErrors({custom: true});
        });
      }
    });
  }
}
