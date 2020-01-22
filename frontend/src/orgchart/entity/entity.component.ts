import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { OrgData } from '../orgData';

@Component({
	selector: 'org-chart-entity',
	templateUrl: './entity.component.html',
	styleUrls: ['./entity.component.scss', '../org-chart-combined.scss']
})
export class EntityComponent implements OnInit {

	@Output() toggleChild = new EventEmitter();
	@Input() data: OrgData;
	@Input() hasParent = false;
	@Input() hideChild;
	@Input() highlight: Array<string>;
	cardClass = 'org-chart-entity-name';

	ngOnInit() {
		const highlightCard = this.highlight.find((s) => s === this.data.id);
		if (highlightCard) { this.cardClass += ' highlighted'; }
	}

	toggleShowChild() {
		this.toggleChild.emit(new Date());
	}
}
