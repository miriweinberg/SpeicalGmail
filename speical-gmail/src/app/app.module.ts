import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewUserComponent } from './project/new-user/new-user.component';
import { HomePageComponent } from './project/home-page/home-page.component';
import { Routes, RouterModule } from '@angular/router';
import bootstrap from "bootstrap";
import { NewMailComponent } from './project/new-mail/new-mail.component';
import { SymbolsPageComponent } from './project/symbols-page/symbols-page.component';
import { FormsModule } from '@angular/forms';
import { SettingsComponent } from './project/settings/settings.component';
import { SymbolSettingComponent } from './project/symbol-setting/symbol-setting.component';
import { ContactsSettingComponent } from './project/contacts-setting/contacts-setting.component';

@NgModule({
  declarations: [
    AppComponent,
    NewUserComponent,
    HomePageComponent,
    NewMailComponent,
    SymbolsPageComponent,
    SettingsComponent,
    SymbolSettingComponent,
    ContactsSettingComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
    
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
