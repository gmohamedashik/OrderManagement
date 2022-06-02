import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  { path: 'orders', redirectTo: 'orders/index', pathMatch: 'full' },
  { path: 'orders/list', component: ListComponent },
  { path: 'orders/:orderId/details', component: DetailsComponent },
  { path: 'orders/create', component: CreateComponent },
  { path: 'orders/:orderId/edit', component: EditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
