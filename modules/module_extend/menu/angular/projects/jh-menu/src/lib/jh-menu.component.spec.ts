import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { JhMenuComponent } from './jh-menu.component';

describe('JhMenuComponent', () => {
  let component: JhMenuComponent;
  let fixture: ComponentFixture<JhMenuComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ JhMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JhMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
