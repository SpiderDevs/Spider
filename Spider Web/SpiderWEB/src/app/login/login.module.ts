import { NgModule } from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {MaterialModule} from '@angular/material';

import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login.component';
import {FlexLayoutModule} from "@angular/flex-layout";

@NgModule({
  imports: [
   CommonModule, RouterModule,
       MaterialModule.forRoot(),
        FlexLayoutModule.forRoot()
  ],
  declarations: [LoginComponent],
   exports: [LoginComponent]
})
export class LoginModule { }
