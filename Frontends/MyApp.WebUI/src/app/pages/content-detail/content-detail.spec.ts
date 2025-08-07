import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentDetail } from './content-detail';

describe('ContentDetail', () => {
  let component: ContentDetail;
  let fixture: ComponentFixture<ContentDetail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContentDetail]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContentDetail);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
