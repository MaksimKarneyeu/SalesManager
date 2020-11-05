import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UploadCsvComponent } from './upload-csv/upload-csv.component'
import { SalesListComponent } from './sales-list/sales-list.component'
import { SaleEditComponent } from './sale-edit/sale-edit.component'

const routes: Routes = [
  { path: 'upload-csv', component: UploadCsvComponent }, 
  { path: 'sales-list/:documentID', component: SalesListComponent }, 
  { path: 'sale-edit/:saleID', component: SaleEditComponent }, 
  { path: '', redirectTo: '/upload-csv', pathMatch: 'full' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
