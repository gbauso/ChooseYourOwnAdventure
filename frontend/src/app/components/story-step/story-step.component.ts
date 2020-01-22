import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-story-step',
  templateUrl: './story-step.component.html',
  styleUrls: ['./story-step.component.scss']
})
export class StoryStepComponent implements OnInit {
  
  @Input() step: Step;
  @Output() choice = new EventEmitter<string>();

  constructor() {}

  ngOnInit() {
  }

  handleChoice(idChoice?: any) {
    this.choice.emit(idChoice);
  }

  public isFinalStep() {
    return this.step.choices.length === 0;
  }
}
