// src/app/app.component.ts
import { Component } from '@angular/core';
import { TestService } from './services/test.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  template: `
    <button (click)="loadCountries()">Load Countries</button>
    <ul>
      <li *ngFor="let country of countries">{{ country.name }}</li>
    </ul>
  `
})
export class AppComponent {
  countries: any[] = [];

  constructor(private testService: TestService) {}

  loadCountries() {
    this.testService.getCountries().subscribe({
      next: (data: any) => {
        console.log('Response:', data);
        this.countries = data;
      },
      error: (err: any) => {
        console.error('Error:', err);
      }
    });
  }
}
