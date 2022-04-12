import { Injectable } from '@angular/core';
import { Request } from './request';
import { REQUESTS } from './mock-requests';
import { Observable, of } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  constructor() { }

  getRequests(): Observable<Request[]> {
    const requests = of(REQUESTS);
    return requests;
  }

  getRequest(id: number): Observable<Request> {
    // TODO: error handling when request(id) does not exist
    const request = REQUESTS.find(r => r.id === id)!;
    return of(request);
  }
}
