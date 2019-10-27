import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewUserComponent } from './project/new-user/new-user.component';
import { HomePageComponent } from './project/home-page/home-page.component';
import { NewMailComponent } from './project/new-mail/new-mail.component';
import { SettingsComponent } from './project/settings/settings.component';
import { SymbolSettingComponent } from './project/symbol-setting/symbol-setting.component';
import { ContactsSettingComponent } from './project/contacts-setting/contacts-setting.component';


const routes: Routes = [
  {path:"" ,component: NewUserComponent},
  {path:"homePage" ,component: HomePageComponent},
  {path:"newMail" ,component: NewMailComponent},
  {path:"settings",component:SettingsComponent},
  {path:"symbolSetting",component:SymbolSettingComponent},
  {path:"contactsSetting",component:ContactsSettingComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
