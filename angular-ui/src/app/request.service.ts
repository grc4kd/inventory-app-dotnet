import { Injectable } from '@angular/core';
import { Request } from './request';
import { REQUESTS } from './mock-requests';
import { Observable, of } from 'rxjs'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  // URL to web api
  private requestsUrl = 'api/requests';

  constructor(
    private http: HttpClient) { }

  getRequests(): Observable<Request[]> {
    return this.http.get<Request[]>(this.requestsUrl)
      .pipe(
        catchError(this.handleError<Request[]>('getRequests', []))
      );
  }

  getRequest(id: number): Observable<Request> {
    const url = `${this.requestsUrl}/${id}`;
    return this.http.get<Request>(url).pipe(
      // error handling when request(id) does not exist
      catchError(this.handleError<Request>(`getRequest id=${id}`))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
    private handleError<T>(operation = 'operation', result?: T) {
      return (error: any): Observable<T> => {

        // TODO: send the error to remote logging infrastructure
        console.error(error); // log to console instead

        // TODO: better job of transforming error for user consumption
        console.error(`${operation} failed: ${error.message}`);

        // Let the app keep running by returning an empty result.
        return of(result as T);
      };
    }
}
