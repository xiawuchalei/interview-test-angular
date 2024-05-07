import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

function getBaseUrl() {
  return 'https://localhost:44335/';
}

@NgModule({
  declarations: [AppComponent, HomeComponent, NavMenuComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent, pathMatch: 'full' },
    ]),
    HttpClientModule,
  ],
  providers: [{ provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }],
  bootstrap: [AppComponent],
})
export class AppModule {}
