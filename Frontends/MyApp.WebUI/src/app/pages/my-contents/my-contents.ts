import { Component, OnInit } from '@angular/core';
import { ContentService } from '../../services/content';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-contents',
  imports: [CommonModule],
  templateUrl: './my-contents.html',
  styleUrls: ['./my-contents.css']
})

export class MyContents implements OnInit {
  contents: any[] = [];

  constructor(
    private contentService: ContentService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadContents();
  }

  loadContents() {
    this.contentService.getMyContents().subscribe({
      next: (data) => {
        this.contents = data;
      },
      error: (err) => {
        console.error('API Hatası:', err);
      }
    });
  }

  editContent(id: number) {
    this.router.navigate(['/contents/edit', id]);
  }

  deleteContent(id: number) {
    if (confirm('Bu içeriği silmek istediğinizden emin misiniz?')) {
      this.contentService.deleteContent(id).subscribe({
        next: () => {
          alert('İçerik silindi');
          this.loadContents(); // Listeyi yenile
        },
        error: (err) => {
          console.error('Silme hatası:', err);
        }
      });
    }
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
