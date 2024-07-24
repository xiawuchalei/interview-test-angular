import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';

import { AppComponent } from "./app.component";
import { RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { AddStudentComponent } from './add-student/add-student.component';

function getBaseUrl() {
  return "http://localhost:5000/";
}

@NgModule({
  declarations: [AppComponent, HomeComponent, NavMenuComponent, AddStudentComponent],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "home", component: HomeComponent, pathMatch: "full" },
      { path: 'add-student', component: AddStudentComponent }
    ]),
    HttpClientModule,
  ],
  providers: [{ provide: "BASE_URL", useFactory: getBaseUrl, deps: [] }],
  bootstrap: [AppComponent],
})
export class AppModule {}
