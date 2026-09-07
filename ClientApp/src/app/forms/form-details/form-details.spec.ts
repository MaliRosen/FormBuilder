import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormDetails } from './form-details';

describe('FormDetails', () => {
  let component: FormDetails;
  let fixture: ComponentFixture<FormDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
