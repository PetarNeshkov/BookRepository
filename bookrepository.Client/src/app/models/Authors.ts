export interface IAuthorUrlParams
{
  name : string;
  bio : string;
}

export interface IAuthor
{
  id : number;
  name : string;
  bio : string;
}

export interface IAuthorName
{
  name : string;
}

export interface IAuthorsModel
{
  authors : IAuthor[];
  authorsTotalCount : number;
}

export interface IAuthorsNamesModel
{
  authors : IAuthorName[];
}
