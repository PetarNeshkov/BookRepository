import { IAuthorName } from "./Authors";

export interface IBookUrlParams
{
  id ?: number;
  title : string;
  description : string;
  publishDate : Date;
  authors : IAuthorName[];
}

export interface IEditBookUrlParams extends IBookUrlParams
{
  originalTitle : string;
  originalDescription : string;
}
