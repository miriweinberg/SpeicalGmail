import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
const api="http://localhost:51806/api/";
@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(public httpClient:HttpClient) { }

  getAllUsers()
  {
   return this.httpClient.get(api+"Users")
  }
}
