import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoryService } from '../../services/story/story.service';

@Component({
	selector: 'app-decision-viewer',
	templateUrl: './decision-viewer.component.html',
	styleUrls: ['./decision-viewer.component.scss']
})
export class DecisionViewerComponent implements OnInit {

	loading = true;
	execution: any;

	constructor(private route: ActivatedRoute, private router: Router, private service: StoryService) { }

	ngOnInit() {
		const storyId = this.route.snapshot.paramMap.get('story');
		const sessionId = this.route.snapshot.paramMap.get('session');
		this.getExecution(storyId, sessionId);
	}

	getExecution(storyId, sessionId) {
		this.service.getExecution(storyId, sessionId).subscribe((data) => {
			this.execution = data;
			this.loading = false;
		},
			err => this.router.navigate(['error']));
	}
}
