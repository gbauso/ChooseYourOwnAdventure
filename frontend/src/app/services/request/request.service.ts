import { Injectable } from '@angular/core';
import {
	HttpClient
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
	providedIn: 'root'
})
export class RequestService {

	constructor(private http: HttpClient) { }

	get<T>(url: string): Observable<T> {
		const requestUrl = this.getRequestUrl(url);

		return this.http.get<T>(requestUrl);
	
	
	}

	post<T>(url: string, body: any): Observable<T> {
		const requestUrl = this.getRequestUrl(url);

		return this.http.post<T>(requestUrl, body);
	}

	private getRequestUrl(url: string) {
		return environment.apiUrl + url;
	}



}
