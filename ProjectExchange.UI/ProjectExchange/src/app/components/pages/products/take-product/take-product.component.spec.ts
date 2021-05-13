import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TakeProductComponent } from './take-product.component';

describe('TakeProductComponent', () => {
  let component: TakeProductComponent;
  let fixture: ComponentFixture<TakeProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TakeProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TakeProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
