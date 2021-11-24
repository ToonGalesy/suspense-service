import { TestBed } from '@angular/core/testing';

import { SuspenseApiService } from './suspense-api.service';

describe('SuspenseApiService', () => {
  let service: SuspenseApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SuspenseApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
