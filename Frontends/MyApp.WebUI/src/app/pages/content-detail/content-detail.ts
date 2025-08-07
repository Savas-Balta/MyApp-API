import { Component, OnInit } from '@angular/core';
import { Content, ContentService } from '../../services/content';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CommentService } from '../../services/comment';

@Component({
  selector: 'app-content-detail',
  imports: [CommonModule, FormsModule],
  templateUrl: './content-detail.html',
  styleUrls: ['./content-detail.css']
})

export class ContentDetail implements OnInit {
  content: any;
  comments: any[] = [];
  newComment: string = '';
  contentId!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private contentService: ContentService,
    private commentService: CommentService
  ) { }

  ngOnInit(): void {
    this.contentId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.contentId) {
      this.loadContent();
      this.loadComments(this.contentId);
    }
  }

  loadContent() {
    this.contentService.getContentById(this.contentId).subscribe({
      next: (data) => {
        this.content = data;
      },
      error: (err) => {
        console.error('Detay yüklenemedi:', err);
      }
    });
  }

  loadComments(contentId: number) {
    this.commentService.getCommentsByContentId(contentId).subscribe({
      next: (data) => {
        this.comments = data;
      },
      error: (err) => console.error('Yorumlar yüklenemedi:', err)
    });
  }

  addComment() {
    if (!this.newComment.trim()) return;

    this.commentService.addComment(this.contentId, this.newComment).subscribe({
      next: () => {
        this.newComment = '';
        this.loadComments(this.contentId); // ✅ Parametre ekledik
      },
      error: (err) => {
        console.error('Yorum eklenemedi:', err);
        alert('Yorum eklemek için giriş yapmalısınız.');
      }
    });
  }

  deleteComment(id: number) {
    if (confirm('Yorumu silmek istediğinize emin misiniz?')) {
      this.commentService.deleteComment(id).subscribe({
        next: () => this.loadComments(this.contentId), // ✅ Parametre ekledik
        error: (err) => console.error('Yorum silinemedi:', err)
      });
    }
  }

  goBack() {
    this.router.navigate(['/contents']);
  }
}