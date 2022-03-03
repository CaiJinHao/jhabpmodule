import { TestBed } from '@angular/core/testing';

import { JhPermissionService } from './jh-permission.service';

describe('JhPermissionService', () => {
  let service: JhPermissionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JhPermissionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
