export interface IAuthorUrlParams {
  name : string;
  bio : string;
}

export interface IAuthor {
  id : number;
  name : string;
  bio : string;
}

export interface IAuthorsModel
{
  authors : IAuthor[];
  authorsTotalCount: number;
}
