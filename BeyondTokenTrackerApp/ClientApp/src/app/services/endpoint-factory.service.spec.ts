import { TestBed } from '@angular/core/testing';

import { EndpointFactory } from './endpoint-factory.service';

describe('EndpointFactory', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EndpointFactory = TestBed.get(EndpointFactory);
    expect(service).toBeTruthy();
  });
});
