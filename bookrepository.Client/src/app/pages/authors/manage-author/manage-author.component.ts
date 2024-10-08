import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthorsService} from '../../../services/authors.service';
import {IAuthor, IAuthorUrlParams, IEditAuthorUrlParams} from '../../../models/Authors';
import {ActivatedRoute, Router} from '@angular/router';
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
  authorId : number | null = null;
  title : string = "Create an Author";

  constructor (
    private fb : FormBuilder,
    private authorsService : AuthorsService,
    private router : Router,
    private route : ActivatedRoute
  ) { }

  ngOnInit () : void
  {
    this.createForm();

    this.route.paramMap.subscribe((params) =>
    {
      this.authorId = params.get('id') ? +params.get('id')! : null;

      if (this.authorId) {
        this.loadAuthorData(this.authorId);
        this.title = "Edit an Author";
      }
    });
  }

  createForm ()
  {
    this.authorForm = this.fb.group({
      name: ['', [Validators.required]],
      bio: ['', [Validators.required]],
      originalName: [''],
      originalBio: ['']
    });
  }

  loadAuthorData (id : number) : void
  {
    this.authorsService.loadAuthorData(id).subscribe({
      next: (response) =>
      {
        this.authorForm.patchValue({
          name: response.name,
          bio: response.bio,
          originalName: response.name,
          originalBio: response.bio
        });
      },
      error: (errors : ValidationError[]) =>
      {
        this.router.navigate(['/notFound']);
      }
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

    const authorData = this.getAuthorFormData();


    this.submitAuthorData(authorData);

  }

  private getAuthorFormData () : IEditAuthorUrlParams
  {
    return {
      name: this.f['name'].value,
      bio: this.f['bio'].value,
      originalName: this.f['originalName'].value,
      originalBio: this.f['originalBio'].value
    };
  }

  private submitAuthorData (authorData : IEditAuthorUrlParams) : void
  {
    if (this.authorId) {
      const request : IEditAuthorUrlParams = {
        id: this.authorId,
        name: authorData.name,
        bio: authorData.bio,
        originalName: authorData.originalName,
        originalBio: authorData.originalBio,
      };

      this.authorsService.updateAuthor(request).subscribe({
        next: (response) => this.handleSuccess(response),
        error: (errors : ValidationError[]) => this.handleErrors(errors),
      });
    } else {
      this.authorsService.createAuthor(authorData).subscribe({
        next: (response) => this.handleSuccess(response),
        error: (errors : ValidationError[]) => this.handleErrors(errors),
      });
    }
  }

  private handleSuccess (response : any) : void
  {
    this.router.navigate(['/authors/list'], {
      state: {successMessage: response}
    });
  }

  private handleErrors (errors : ValidationError[]) : void
  {
    errors.forEach(err =>
    {
      const formControlName = err.propertyName.charAt(0).toLowerCase() + err.propertyName.slice(1);

      this.errorMessage[formControlName] = err.errorMessage;
      this.authorForm.get(formControlName)?.setErrors({custom: true});
    });
  }
}
