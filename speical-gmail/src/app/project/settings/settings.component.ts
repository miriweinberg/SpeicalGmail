import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {

  settings:boolean=true;
  constructor() { }

  ngOnInit() {
  }
  changeToContacts(){
    this.settings=false;
  }
  changeToSymbols(){
    this.settings=true;
  }
}
