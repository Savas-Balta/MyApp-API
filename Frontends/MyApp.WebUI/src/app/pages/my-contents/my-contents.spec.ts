import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyContents } from './my-contents';

describe('MyContents', () => {
  let component: MyContents;
  let fixture: ComponentFixture<MyContents>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MyContents]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyContents);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
