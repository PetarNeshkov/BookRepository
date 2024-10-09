import {environment as env} from '../../../src/environments/environment';

const baseApiUrl = `${ env.baseUrl }/api`;
const baseGetAll = 'GetAll';

const AUTHOR_CONTROLLER_ROUTE = baseApiUrl + '/Authors/';
const BOOK_CONTROLLER_ROUTE = baseApiUrl + '/Books/';
const BOOK_CHANGES_CONTROLLER_ROUTE = baseApiUrl + '/BooksChanges/';


export const AUTHOR_URLS = {
  CREATE_AUTHOR: `${ AUTHOR_CONTROLLER_ROUTE }` + 'CreateAuthor',
  UPDATE_AUTHOR: `${ AUTHOR_CONTROLLER_ROUTE }` + 'UpdateAuthor',
  ALL_AUTHORSBYPAGE: `${ AUTHOR_CONTROLLER_ROUTE }` + baseGetAll,
  GETAUTHORSNAMES: `${ AUTHOR_CONTROLLER_ROUTE }` + 'GetAllAuthorsNames',
  GETAUTHORDATA: `${ AUTHOR_CONTROLLER_ROUTE }` + 'GetAuthorData'
};

export const BOOK_URLS = {
  ALLBOOKS: `${ BOOK_CONTROLLER_ROUTE }` + baseGetAll,
  GETBOOKATA: `${ BOOK_CONTROLLER_ROUTE }` + 'GetBookData',
  CREATE_BOOK: `${ BOOK_CONTROLLER_ROUTE }` + 'CreateBook',
  UPDATE_BOOK: `${ BOOK_CONTROLLER_ROUTE }` + 'UpdateBook',
  DELETE_BOOK: `${ BOOK_CONTROLLER_ROUTE }` + 'DeleteBook',
};

export const BOOK_CHANGES_URLS = {
  ALL_BOOK_HISTORIES: `${ BOOK_CHANGES_CONTROLLER_ROUTE }` + baseGetAll,
};
