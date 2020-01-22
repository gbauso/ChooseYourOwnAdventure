import { Component, OnInit } from '@angular/core';
import { StoryService } from 'src/app/services/story/story.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-stories-list',
  templateUrl: './stories-list.component.html',
  styleUrls: ['./stories-list.component.scss']
})
export class StoriesListComponent implements OnInit {

  stories: Array<SimpleStory>;
  loading = false;

  constructor(private service: StoryService, private router: Router) { }

  ngOnInit() {
    this.getStories();
  }

  getStories() {
    this.service.getStories().subscribe((result: Array<SimpleStory>) => {
      this.stories = result;
    },
    err => this.stories = []);
  }

  redirect(idStory) {
    this.router.navigate(['', idStory]);
  }

}
