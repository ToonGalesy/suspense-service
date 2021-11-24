import { Component, OnInit } from '@angular/core';
import { SuspenseApiService } from './suspense-api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit {
  title = 'Suspense Service';
  submissions: any = [];
  columnsToDisplay = ['SubmissionType','SubmissionDate','SubmissionStatusId'];

  constructor(private suspenseapi:SuspenseApiService){
    console.log('app component constructor called');         
  } 
  
  ngOnInit() {
    //load submissions
    this.suspenseapi.initSubmissions().subscribe((data: any) => this.submissions = data['value']);

    console.log(this.submissions)
  }  
}
