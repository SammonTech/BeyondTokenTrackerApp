import { TestBed } from '@angular/core/testing';

import { UserEndpoint } from './user-endpoint.service';

describe('UserEndpointService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserEndpoint = TestBed.get(UserEndpoint);
    expect(service).toBeTruthy();
  });
});
