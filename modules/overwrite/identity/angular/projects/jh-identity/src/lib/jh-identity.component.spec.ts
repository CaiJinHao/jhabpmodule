import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { JhIdentityComponent } from './jh-identity.component';

describe('JhIdentityComponent', () => {
  let component: JhIdentityComponent;
  let fixture: ComponentFixture<JhIdentityComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ JhIdentityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JhIdentityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
