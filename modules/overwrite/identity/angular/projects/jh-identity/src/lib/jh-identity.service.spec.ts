import { TestBed } from '@angular/core/testing';

import { JhIdentityService } from './jh-identity.service';

describe('JhIdentityService', () => {
  let service: JhIdentityService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JhIdentityService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
