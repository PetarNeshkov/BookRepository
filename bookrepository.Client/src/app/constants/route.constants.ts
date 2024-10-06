import {environment as env} from '../../../src/environments/environment';

const baseApiUrl = `${ env.baseUrl }/api`;
const baseGetAll = 'GetAll';

const AUTHOR_CONTROLLER_ROUTE = baseApiUrl + '/Authors/';
const BOOK_CONTROLLER_ROUTE = baseApiUrl + '/Books/';
const BOOK_HISTORY_CONTROLLER_ROUTE = baseApiUrl + '/Booksistories/';


export const AUTHOR_URLS = {
  CREATE_AUTHOR: `${ AUTHOR_CONTROLLER_ROUTE }` + 'CreateAuthor',

};
