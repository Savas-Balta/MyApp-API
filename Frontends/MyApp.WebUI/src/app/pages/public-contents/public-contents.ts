import { Component, OnInit } from '@angular/core';
import { Content, ContentService } from '../../services/content';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-public-contents',
  imports: [CommonModule],
  templateUrl: './public-contents.html',
  styleUrls: ['./public-contents.css']
})

export class PublicContents implements OnInit {
  contents: any[] = [];

  constructor(private contentService: ContentService, private router: Router) { }

  ngOnInit(): void {
    this.loadContents();
  }

  loadContents() {
    this.contentService.getPublicContents().subscribe({
      next: (data) => this.contents = data,
      error: (err) => console.error('API Hatası:', err)
    });
  }

  goToDetail(id: number) {
    this.router.navigate(['/contents', id]);
  }

  vote(contentId: number, isLike: boolean) {
    this.contentService.vote(contentId, isLike).subscribe({
      next: () => {
        this.loadContents();
      },
      error: (err) => {
        console.error('Oy gönderilirken hata:', err);
        alert('Oylama başarısız oldu. Giriş yapmış olmalısınız.');
      }
    });
  }
}
