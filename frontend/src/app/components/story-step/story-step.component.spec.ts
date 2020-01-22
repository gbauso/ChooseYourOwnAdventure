import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryStepComponent } from './story-step.component';

describe('StoryStepComponent', () => {
  let component: StoryStepComponent;
  let fixture: ComponentFixture<StoryStepComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoryStepComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoryStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
