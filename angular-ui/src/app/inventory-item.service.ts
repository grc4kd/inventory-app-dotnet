import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { InventoryItem } from './inventory-item';

@Injectable({
  providedIn: 'root'
})
export class InventoryItemService {
  // URL to web api
  private inventoryUrl = 'api/inventory';

  constructor(
    private http: HttpClient) { }

  getInventory(): Observable<InventoryItem[]> {
    return this.http.get<InventoryItem[]>(this.inventoryUrl)
      .pipe(
        catchError(this.handleError<InventoryItem[]>('getRequests', []))
      );
  }

  /**
   * get an inventory item, looking it up by id
   * @param id
   */
  getInventoryItem(id: number): Observable<InventoryItem> {
    const url = `${this.inventoryUrl}/${id}`;
    return this.http.get<InventoryItem>(url).pipe(
      // error handling when request(id) does not exist
      catchError(this.handleError<InventoryItem>(`getRequest id=${id}`))
    );
  }

  // TODO: display a warning message if the request quantity exceeds stock quantity
  // causing a backorder

  /**
   * returns true if there are enough kernels in stock
   * returns false if request quantity exceeds stock quantity
   * @param requestedKernels the requested number of kernels
   */
  async checkStock(itemID: number, requestedKernels: number): Promise<boolean> {
    const inventoryItem = await this.getInventoryItem(itemID).toPromise();

    if (inventoryItem) {
      return inventoryItem.kernels >= requestedKernels;
    }

    return false; // no kernels to count
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
