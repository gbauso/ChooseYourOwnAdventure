import { TestBed } from '@angular/core/testing';

import { StoryServiceService } from './story-service.service';

describe('StoryServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StoryServiceService = TestBed.get(StoryServiceService);
    expect(service).toBeTruthy();
  });
});
