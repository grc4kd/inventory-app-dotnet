import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RequestsComponent } from './requests.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('RequestsComponent', () => {
  let component: RequestsComponent;
  let fixture: ComponentFixture<RequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RequestsComponent],
      imports: [RouterTestingModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
