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
}
