import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

export interface Content {
  id: number;
  title: string;
  body: string;
  userName: string;
  categoryName: string;
  createdAt: string;
}

@Injectable({
  providedIn: 'root'
})
export class ContentService {
  private apiUrl = 'http://localhost:5001/api/Content';

  constructor(private http: HttpClient) { }

  getPublicContents(): Observable<Content[]> {
    return this.http.get<Content[]>(`${this.apiUrl}/PublicContents`);
  }

  getMyContents(): Observable<Content[]> {
    return this.http.get<Content[]>(`${this.apiUrl}/MyContents`);
  }

  deleteContent(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }


  addContent(content: any): Observable<any> {
    return this.http.post(`${this.apiUrl}`, content);
  }

  updateContent(id: number, content: any): Observable<any> {
    return this.http.put(`${this.apiUrl}`, { id, ...content });
  }

  getContentById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  vote(contentId: number, isLike: boolean): Observable<any> {
    return this.http.post(`${this.apiUrl+"Vote"}/Vote`, { contentId, isLike });
  }
}
