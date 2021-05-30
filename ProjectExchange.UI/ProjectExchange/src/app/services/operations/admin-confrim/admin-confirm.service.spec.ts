import { TestBed } from '@angular/core/testing';

import { AdminConfirmService } from './admin-confirm.service';

describe('AdminConfirmService', () => {
  let service: AdminConfirmService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminConfirmService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
