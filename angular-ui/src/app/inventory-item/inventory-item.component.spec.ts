import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InventoryItemComponent } from './inventory-item.component';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing'

describe('InventoryItemComponent', () => {
  let component: InventoryItemComponent;
  let fixture: ComponentFixture<InventoryItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InventoryItemComponent],
      imports: [RouterTestingModule, HttpClientTestingModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InventoryItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
