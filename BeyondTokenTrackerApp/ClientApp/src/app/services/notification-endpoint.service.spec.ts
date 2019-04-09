import { TestBed } from '@angular/core/testing';

import { NotificationEndpoint } from './notification-endpoint.service';

describe('NotificationEndpoint', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NotificationEndpoint = TestBed.get(NotificationEndpoint);
    expect(service).toBeTruthy();
  });
});
