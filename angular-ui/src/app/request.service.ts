import { Injectable } from '@angular/core';
import { Request } from './request';
import { REQUESTS } from './mock-requests';
import { Observable, of } from 'rxjs'
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  // URL to web api
  private requestsUrl = 'api/requests';

  constructor(
    private http: HttpClient) { }

  getRequests(): Observable<Request[]> {
    return this.http.get<Request[]>(this.requestsUrl);
  }

  getRequest(id: number): Observable<Request> {
    // TODO: error handling when request(id) does not exist
    const request = REQUESTS.find(r => r.id === id)!;
    return of(request);
  }
}
