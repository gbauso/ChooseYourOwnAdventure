import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoriesListComponent } from './components/stories-list/stories-list.component';
import { RequestService } from './services/request/request.service';
import { StoryService } from './services/story/story.service';
import { HttpClientModule } from '@angular/common/http';
import { StoryRunnerComponent } from './components/story-runner/story-runner.component';
import { StoryStepComponent } from './components/story-step/story-step.component';
import { DecisionViewerComponent } from './components/decision-viewer/decision-viewer.component';

import { OrgChartModule } from '../orgchart/org-chart.module';
import { ErrorComponent } from './error/error.component';
import { SortByPipe } from './pipes/sort-by.pipe';

@NgModule({
  declarations: [
    AppComponent,
    StoriesListComponent,
    StoryRunnerComponent,
    StoryStepComponent,
    DecisionViewerComponent,
    ErrorComponent,
    SortByPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    OrgChartModule
  ],
  providers: [RequestService, StoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
