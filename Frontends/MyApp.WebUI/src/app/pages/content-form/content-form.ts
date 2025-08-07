import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContentService } from '../../services/content';
import { CategoryService } from '../../services/category';

@Component({
  selector: 'app-content-form',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './content-form.html',
  styleUrls: ['./content-form.css']
})
export class ContentForm implements OnInit {
  form!: FormGroup;
  isEditMode = false;
  contentId!: number;
  categories: any[] = [];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private contentService: ContentService,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      title: ['', Validators.required],
      body: ['', Validators.required],
      categoryId: ['', Validators.required]
    });

    this.loadCategories();

    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      if (idParam) {
        this.isEditMode = true;
        this.contentId = +idParam;
        this.loadContent(this.contentId);
      }
    });
  }

  loadCategories() {
    this.categoryService.getAllCategories().subscribe({
      next: (data) => this.categories = data,
      error: (err) => console.error('Kategori yükleme hatası:', err)
    });
  }

  loadContent(id: number) {
    this.contentService.getContentById(id).subscribe({
      next: (data) => {
        this.form.patchValue({
          title: data.title,
          body: data.body,
          categoryId: data.categoryId
        });
      }
    });
  }

  save() {
    if (this.form.invalid) return;

    const contentData = this.form.value;

    if (this.isEditMode) {
      this.contentService.updateContent(this.contentId, contentData).subscribe({
        next: () => {
          alert('İçerik güncellendi');
          this.router.navigate(['/my-contents']);
        }
      });
    } else {
      this.contentService.addContent(contentData).subscribe({
        next: () => {
          alert('İçerik eklendi');
          this.router.navigate(['/my-contents']);
        }
      });
    }
  }

  cancel() {
    this.router.navigate(['/my-contents']);
  }
}