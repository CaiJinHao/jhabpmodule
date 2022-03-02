import { TestBed } from '@angular/core/testing';

import { YourProjectNameService } from './your-project-name.service';

describe('YourProjectNameService', () => {
  let service: YourProjectNameService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(YourProjectNameService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
