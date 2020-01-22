import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryRunnerComponent } from './story-runner.component';

describe('StoryRunnerComponent', () => {
  let component: StoryRunnerComponent;
  let fixture: ComponentFixture<StoryRunnerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoryRunnerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoryRunnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
