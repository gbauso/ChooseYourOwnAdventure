import { Component, Input } from '@angular/core';
import { OrgData } from '../orgData';

@Component({
	selector: 'angular-org-chart',
	templateUrl: './org-chart.component.html',
	styleUrls: ['./org-chart.component.scss', '../org-chart-combined.scss']
})
export class OrgChartComponent {
	@Input() data: OrgData;
	@Input() highlight: Array<string>;
	@Input() hasParent = false;
	hideChild = false;
	
	
	toggleShowChild(value){
		this.hideChild = !this.hideChild;
	}
}
