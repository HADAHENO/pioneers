import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

// Standalone Components
import { AppComponent } from './app.component';
import { CountriesComponent } from './countries/countries.component';

// DevExtreme
import { DxDataGridModule } from 'devextreme-angular';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    DxDataGridModule,
    AppComponent,        // standalone component
    CountriesComponent   // standalone component
  ],
  providers: [],
  bootstrap: [AppComponent] // فقط bootstrap
})
export class AppModule { }
