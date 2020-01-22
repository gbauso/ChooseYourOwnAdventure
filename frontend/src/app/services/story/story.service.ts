import { Injectable } from '@angular/core';
import { RequestService } from '../request/request.service';
import { Observable } from 'rxjs';
import { Story } from 'src/app/model/story';

@Injectable({
  providedIn: 'root'
})
export class StoryService {

  constructor(private service: RequestService) { }

  getStories(): Observable<Array<SimpleStory>> {
    const url = 'api/story';

    return this.service.get<Array<SimpleStory>>(url);
  }

  getStory(id: string): Observable<Story> {
    const url = `api/story/${id}`;

    return this.service.get<Story>(url);
  }

  getExecution(storyId: string, sessionId: string): Observable<any> {
    const url = `api/story/moves/${storyId}/${sessionId}`;

    return this.service.get<Story>(url);
  }


}
