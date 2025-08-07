import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicContents } from './public-contents';

describe('PublicContents', () => {
  let component: PublicContents;
  let fixture: ComponentFixture<PublicContents>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PublicContents]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PublicContents);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
