import { TestBed } from '@angular/core/testing';

import { TokenTypeService } from './token-type.service';

describe('TokenTypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TokenTypeService = TestBed.get(TokenTypeService);
    expect(service).toBeTruthy();
  });
});
