import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
const api="http://localhost:51806/api/";
@Injectable({
  providedIn: 'root'
})
export class ContactServiceService {

  constructor(public httpClient:HttpClient) { }

  getAlllContact()
  {
   return this.httpClient.get(api+"Contacts")
  }
}
