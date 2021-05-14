import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellOperationComponent } from './sell-operation.component';

describe('SellOperationComponent', () => {
  let component: SellOperationComponent;
  let fixture: ComponentFixture<SellOperationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SellOperationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SellOperationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
