import { Route } from '@angular/router';

import { HomeRoutes } from './home/index';
import { DashboardComponent } from './index';

export const DashboardRoutes: Route[] = [
  	{
    	path: 'dashboard',
    	component: DashboardComponent,
    	children: [
	    	...HomeRoutes,	    
    	]
  	}
];
