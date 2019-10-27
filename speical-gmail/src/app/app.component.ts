import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'speical-gmail';
  contacts: Object;

  /**
   *
   */
  // constructor(public contactService:ContactServiceService) {
  //   this.contactService.getAlllContact().subscribe(res=>{
  //     this.contacts=res;
  //   })
    
  // }
  
}
