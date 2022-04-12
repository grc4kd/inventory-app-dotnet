import { Injectable } from '@angular/core';
import { Request } from './request';
import { REQUESTS } from './mock-requests';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  constructor() { }

  getRequests(): Request[] {
    return REQUESTS;
  }
}
