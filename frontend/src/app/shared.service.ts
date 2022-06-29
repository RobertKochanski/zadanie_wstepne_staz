import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl_Author = 'https://localhost:7028/api/Author';
readonly APIUrl_Book = 'https://localhost:7028/api/Book';

  constructor(private http:HttpClient) { }

  getAuthorList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl_Author+'/GetAuthors');
  }

  addAuthor(val:any){
    return this.http.post(this.APIUrl_Author+'/AddAuthor', val);
  }

  updateAuthor(val:any){
    return this.http.put(this.APIUrl_Author+'/UpdateAuthor', val);
  }

  deleteAuthor(val:any){
    return this.http.delete(this.APIUrl_Author+'/DeleteAuthor' + val);
  }

  getBookList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl_Book+'/GetBooks');
  }

  addBook(val:any){
    return this.http.post(this.APIUrl_Book+'/AddBook', val);
  }

  updateBook(val:any){
    return this.http.put(this.APIUrl_Book+'/UpdateBook', val);
  }

  deleteBook(val:any){
    return this.http.delete(this.APIUrl_Book+'/DeleteBook' + val);
  }
}
