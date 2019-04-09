import { TestBed } from '@angular/core/testing';

import { TokenTypeEndpoint } from './token-type-endpoint.service';

describe('TokenTypeEndpointService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TokenTypeEndpoint = TestBed.get(TokenTypeEndpoint);
    expect(service).toBeTruthy();
  });
});
