import {IAuthorName} from "./Authors";

export interface IBookUrlParams
{
  id ?: number;
  title : string;
  description : string;
  publishDate : Date;
  authors : IAuthorName[];
}

export interface IBook extends Omit<IBookUrlParams, 'publishDate'>
{
  publishDate : Date | null;
  originalTitle : string;
  originalDescription : string;
}

export interface IBooksModel
{
  books : IBookUrlParams[];
  booksTotalCount : number;
}

export interface IFilterParams
{
  query : string;
  byTitle : boolean;
  byAuthor : boolean;
  sortDirection : string;
  page : number;
}
