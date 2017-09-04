import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneCsvComponent } from './phone-csv.component';

describe('PhoneCsvComponent', () => {
  let component: PhoneCsvComponent;
  let fixture: ComponentFixture<PhoneCsvComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhoneCsvComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhoneCsvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
