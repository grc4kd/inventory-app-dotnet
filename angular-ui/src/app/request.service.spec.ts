import { TestBed, ComponentFixture } from '@angular/core/testing';
import { RequestService } from './request.service';
import { HttpClientTestingModule } from '@angular/common/http/testing'
import { RequestsComponent } from './requests/requests.component';

describe('RequestService', () => {
  let service: RequestService;
  let fixture: ComponentFixture<RequestsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(RequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
