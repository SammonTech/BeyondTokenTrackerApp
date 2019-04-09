import { TestBed } from '@angular/core/testing';

import { LocalStoreManager } from './local-store-manager.service';

describe('LocalStoreManager', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LocalStoreManager = TestBed.get(LocalStoreManager);
    expect(service).toBeTruthy();
  });
});
