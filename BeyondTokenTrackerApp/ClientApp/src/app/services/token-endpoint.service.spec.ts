import { TestBed } from '@angular/core/testing';

import { TokenEndpoint } from './token-endpoint.service';

describe('TokenEndpoint', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TokenEndpoint = TestBed.get(TokenEndpoint);
    expect(service).toBeTruthy();
  });
});
