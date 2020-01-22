import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoryService } from 'src/app/services/story/story.service';
import { Guid } from 'guid-typescript';
import { Story } from 'src/app/model/story';
import { forkJoin } from 'rxjs';
import { StepService } from '../../services/step/step.service';

@Component({
	selector: 'app-story-runner',
	templateUrl: './story-runner.component.html',
	styleUrls: ['./story-runner.component.scss']
})
export class StoryRunnerComponent implements OnInit {

	story: Story;
	currentStep: Step;
	session: string;
	loading = true;

	constructor(private route: ActivatedRoute,
		private router: Router,
		private storyService: StoryService,
		private stepService: StepService) { }

	ngOnInit() {
		const id = this.route.snapshot.paramMap.get('id');
		this.getStory(id);
		this.session = Guid.create().toString();
	}

	getStory(id: string) {
		this.storyService
			.getStory(id)
			.subscribe((result: Story) => {
				this.story = result;
				this.currentStep = this.story.root;
				this.loading = false;
			},
			err => this.router.navigate(['error']));
	}

	getNextStep($event) {
		if ($event !== null) {
			this.reachNextStep($event);
		} else {
			this.finish();
		}
	}

	reachNextStep(idChoice: string) {
		const nextStep = this.stepService.getNextStep(this.currentStep.id, idChoice);
		const saveStep = this.stepService.insertMove(this.session, this.currentStep.id, idChoice);

		forkJoin(saveStep, nextStep).subscribe(response => {
			if (response[0]) {
				this.currentStep = response[1];
				this.loading = false;
			}
		},
		err => this.router.navigate(['error']));
	}

	finish() {
		this.stepService
			.insertMove(this.session, this.currentStep.id)
			.subscribe((result) => {
				if (result) { this.router.navigate(['view', this.story.id, this.session]); }
			},
			err => this.router.navigate(['error']));
	}
}
