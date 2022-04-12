import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RequestsComponent } from './requests/requests.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RequestDetailComponent } from './request-detail/request-detail.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'requests', component: RequestsComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'detail/:id', component: RequestDetailComponent },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
