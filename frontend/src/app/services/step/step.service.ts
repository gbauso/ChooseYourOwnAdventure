import { Injectable } from '@angular/core';
import { RequestService } from '../request/request.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StepService {

  constructor(private service: RequestService) { }

  insertMove(sessionId: string, currentStepId: string, choiceId?: string): Observable<boolean> {
    const url = 'api/step/move';
    const body = {sessionId, currentStepId, choiceId};

    return this.service.post<boolean>(url, body);
  }

  getNextStep(stepId: string, choiceId: string): Observable<Step> {
    const url = `api/step/${stepId}/${choiceId}`;

    return this.service.get<Step>(url);
  }

}
