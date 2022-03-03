import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { JhPermissionComponent } from './jh-permission.component';

describe('JhPermissionComponent', () => {
  let component: JhPermissionComponent;
  let fixture: ComponentFixture<JhPermissionComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ JhPermissionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JhPermissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
