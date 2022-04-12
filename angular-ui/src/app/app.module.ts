import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { RequestsComponent } from './requests/requests.component';
import { InventoryItemComponent } from './inventory-item/inventory-item.component';
import { RequestDetailComponent } from './request-detail/request-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    RequestsComponent,
    InventoryItemComponent,
    RequestDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
