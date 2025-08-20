import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class CountryService {
  private base = environment.apiUrl + '/api/Countries';
  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get(this.base).toPromise().then((r: any) => r);
  }

  add(country: any) {
    return this.http.post(this.base, country).toPromise().then((r: any) => r);
  }
  update(country: any) {
    return this.http.put(`${this.base}/${country.id}`, country).toPromise().then((r: any) => r);
  }

  delete(id: number) {
    return this.http.delete(`${this.base}/${id}`).toPromise();
  }
}
