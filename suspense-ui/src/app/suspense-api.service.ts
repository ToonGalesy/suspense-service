import { Injectable } from '@angular/core';
import { HttpClient  } from '@angular/common/http';
import { Config } from './submission';

@Injectable({
  providedIn: 'root'
})
export class SuspenseApiService {

  constructor(private http:HttpClient) { }

  submissionBaseUrl = "https://pgsuspenseservice.azurewebsites.net/odata/Submissions"

  initSubmissions(){
    return this.http.get(this.submissionBaseUrl);
 }  
}
