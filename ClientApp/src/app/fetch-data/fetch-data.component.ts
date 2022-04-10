import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public inventories: Inventory[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Inventory[]>(baseUrl + 'inventory').subscribe(result => {
      this.inventories = result;
    }, error => console.error(error));
  }
}

interface Inventory {
  id: number;
  name: string;
  kernels: number;
}
