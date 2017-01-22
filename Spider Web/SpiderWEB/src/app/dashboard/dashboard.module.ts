import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { HomeModule } from './home/home.module';
import { DashboardComponent } from './dashboard.component';


@NgModule({
    imports: [
        CommonModule,
    	RouterModule,
        HomeModule    	
    ],
    declarations: [DashboardComponent ],
    exports: [DashboardComponent]
})

export class DashboardModule { }
