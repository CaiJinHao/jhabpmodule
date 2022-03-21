import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { YourProjectNameComponent } from './your-project-name.component';

describe('YourProjectNameComponent', () => {
  let component: YourProjectNameComponent;
  let fixture: ComponentFixture<YourProjectNameComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ YourProjectNameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YourProjectNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
