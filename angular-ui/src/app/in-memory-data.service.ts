import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Request } from './request';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const requests = [
      { id: 11, name: "24697-013-01-05", quantity: 10 },
      { id: 12, name: "24698-019-01-10", quantity: 12 },
      { id: 13, name: "24697-013-01-05", quantity: 20 },
      { id: 14, name: "24699-009-01-08", quantity: 13 },
      { id: 15, name: "24698-019-01-10", quantity: 40 },
      { id: 16, name: "24699-009-01-08", quantity: 15 },
    ];
    return { requests };
  }
    
  // Overrides the genId method to ensure that a request always has an id.
  // If the requests array is empty,
  // the method below returns the initial number (1).
  // if the requests array is not empty, the method below returns the highest
  // request id + 1.
  genId(requests: Request[]): number {
    return requests.length > 0 ? Math.max(...requests.map(request => request.id)) + 1 : 1;
  }
}
