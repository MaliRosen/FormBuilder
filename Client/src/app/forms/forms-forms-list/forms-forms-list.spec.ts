import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormsFormsList } from './forms-forms-list';

describe('FormsFormsList', () => {
  let component: FormsFormsList;
  let fixture: ComponentFixture<FormsFormsList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormsFormsList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormsFormsList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
