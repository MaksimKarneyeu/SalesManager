import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import  SalesService  from './shared/services/sale.service';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UploadCsvComponent } from './upload-csv/upload-csv.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { DocumentsListComponent } from './documents-list/documents-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { SalesListComponent } from './sales-list/sales-list.component';
import { MatListModule } from '@angular/material/list';
import { MatSortModule} from '@angular/material/sort';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { SaleEditComponent } from './sale-edit/sale-edit.component';
import { MatSelectModule} from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { AggregationComponent } from './aggregation/aggregation.component';


@NgModule({
  declarations: [
    AppComponent,
    UploadCsvComponent,
    DocumentsListComponent,
    SalesListComponent,
    ToolbarComponent,
    SaleEditComponent,
    AggregationComponent    
  ],
  imports: [
    MatIconModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatToolbarModule,
    MatProgressBarModule,
    MatTableModule,
    MatPaginatorModule,
    MatListModule,
    MatSortModule,
    MatSelectModule,   
    FormsModule,
    ReactiveFormsModule,
    NgxChartsModule    
  ],
  providers: [SalesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
