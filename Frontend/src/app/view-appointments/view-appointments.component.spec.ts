import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAppointmentsCompontent } from './view-appointments.component';

describe('ViewAppointmentsCompontent', () => {
  let component: ViewAppointmentsCompontent;
  let fixture: ComponentFixture<ViewAppointmentsCompontent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAppointmentsCompontent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewAppointmentsCompontent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
