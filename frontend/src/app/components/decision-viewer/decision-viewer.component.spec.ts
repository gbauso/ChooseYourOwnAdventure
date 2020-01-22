import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DecisionViewerComponent } from './decision-viewer.component';

describe('DecisionViewerComponent', () => {
  let component: DecisionViewerComponent;
  let fixture: ComponentFixture<DecisionViewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DecisionViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DecisionViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
