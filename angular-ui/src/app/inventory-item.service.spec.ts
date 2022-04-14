import { TestBed } from '@angular/core/testing';

import { InventoryItemService } from './inventory-item.service';
import { HttpClientTestingModule } from '@angular/common/http/testing'

describe('InventoryItemService', () => {
  let service: InventoryItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(InventoryItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
