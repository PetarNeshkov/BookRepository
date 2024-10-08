export interface IAuthorUrlParams
{
  name : string;
  bio : string;
}

export interface IAuthor
{
  id ?: number;
  name : string;
  bio : string;
}

export interface IAuthorName
{
  id: number;
  name : string;
}

export interface IAuthorsModel
{
  authors : IAuthor[];
  authorsTotalCount : number;
}

export interface IEditAuthorUrlParams extends IAuthor
{
  originalName : string;
  originalBio : string;
};
