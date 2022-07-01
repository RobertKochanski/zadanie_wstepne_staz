import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookComponent } from './book/book.component';
import { ShowBookComponent } from './book/show-book/show-book.component';
import { AddEditBookComponent } from './book/add-edit-book/add-edit-book.component';
import { AuthorComponent } from './author/author.component';
import { ShowAuthorComponent } from './author/show-author/show-author.component';
import { AddEditAuthorComponent } from './author/add-edit-author/add-edit-author.component';
import { SharedService } from './shared.service';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';

@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    ShowBookComponent,
    AddEditBookComponent,
    AuthorComponent,
    ShowAuthorComponent,
    AddEditAuthorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
