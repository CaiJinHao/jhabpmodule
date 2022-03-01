import { TestBed } from '@angular/core/testing';

import { JhMenuService } from './jh-menu.service';

describe('JhMenuService', () => {
  let service: JhMenuService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JhMenuService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
