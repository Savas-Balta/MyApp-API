import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CommentService {
  private apiUrl = 'http://localhost:5001/api/Comment';

  constructor(private http: HttpClient) { }

  getCommentsByContentId(contentId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/content/${contentId}`);
  }

  addComment(contentId: number, text: string): Observable<any> {
    return this.http.post(`${this.apiUrl}`, {
      contentId,
      text
    });
  }

  deleteComment(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getCommentsByUserId(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/user/${userId}`);
  }

  updateComment(id: number, text: string): Observable<any> {
    return this.http.put(`${this.apiUrl}`, {
      id,
      text
    });
  }
}