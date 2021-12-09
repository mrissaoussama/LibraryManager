import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NumberSymbol } from '@angular/common';
import { Observable } from 'rxjs';
const BOOK_API = 'http://localhost:8080/api/book/';
const httpOptions = {headers: new HttpHeaders({ 'Content-Type': 'application/json' })};
const HttpUploadOptions = {headers: new HttpHeaders({})}
@Injectable({providedIn: 'root'})
export class BookService {
  constructor(private http: HttpClient) { }
  getLast10Products(): Observable<any> {
    return this.http.post(BOOK_API + 'ListAllBooks',{});
  }
}
