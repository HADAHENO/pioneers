import { Component, OnInit } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { CountryService } from '../services/country.service';
import { DxDataGridModule } from 'devextreme-angular';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-countries',
  standalone: true,                 // دي لازم
  imports: [CommonModule, DxDataGridModule],  // أي modules محتاجها
  template: `
    <div dx-data-grid [dataSource]="store"
         [editing]="{allowAdding:true,allowUpdating:true,allowDeleting:true,mode:'row'}"
         [columns]="cols"
         [searchPanel]="{visible:true}"
         [paging]="{pageSize:10}">
    </div>
  `
})
export class CountriesComponent implements OnInit {
  store: any;
  cols = [
    { dataField: 'id', allowEditing: false },
    { dataField: 'name' }
  ];

  constructor(private countryService: CountryService) { }

  ngOnInit() {
    this.store = new CustomStore({
      key: 'id',
      load: () => this.countryService.getAll(),
      insert: (v: any) => this.countryService.add(v).then(() => {}),
      update: (key: any, v: any) => this.countryService.update({ id: key, ...v }).then(() => {}),
      remove: (key: any) => this.countryService.delete(key).then(() => {})
    });
  }
}
