import { TestBed } from '@angular/core/testing';
import { RequestService } from './request.service';
import { HttpClientTestingModule } from '@angular/common/http/testing'

describe('RequestService', () => {
  let service: RequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(RequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return requests from endpoint', () => {
    let requests: Request[] = [];
    service.getRequests()
      .subscribe(requests => requests = requests)
    expect(requests.length).toBeGreaterThan(0);
  });
});
