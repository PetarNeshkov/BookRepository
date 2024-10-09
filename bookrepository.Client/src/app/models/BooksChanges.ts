export interface IBooksChanges
{
  changeTime : Date;
  changeDescription : string;
}

export interface IBooksChangesModel
{
  booksChanges : IBooksChanges[];
  booksChangesTotalCount : number;
}
