import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StoriesListComponent } from './components/stories-list/stories-list.component';
import { StoryRunnerComponent } from './components/story-runner/story-runner.component';
import { DecisionViewerComponent } from './components/decision-viewer/decision-viewer.component';
import { ErrorComponent } from './error/error.component';


const routes: Routes = [
  { path: '', component: StoriesListComponent},
  { path: 'error', component: ErrorComponent},
  { path: ':id', component: StoryRunnerComponent},
  { path: 'view/:story/:session', component: DecisionViewerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
