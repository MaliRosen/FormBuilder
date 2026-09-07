import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormsService } from '../forms.service';

@Component({
  selector: 'app-form-create',
  templateUrl: './form-create.component.html',
  styleUrl: './form-create.component.css'
})
export class FormCreateComponent {

  form: FormGroup;

constructor(
  private fb: FormBuilder,
  private formsService: FormsService
) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      createdBy: ['', Validators.required],

      fields: this.fb.array([]),

      approvalSteps: this.fb.array([])
    });

  }

  get fields(): FormArray {
    return this.form.get('fields') as FormArray;
  }

  get approvalSteps(): FormArray {
    return this.form.get('approvalSteps') as FormArray;
  }

  addField(): void {
    const field = this.fb.group({
      label: ['', Validators.required],
      fieldType: ['text', Validators.required]
    });

    this.fields.push(field);
  }

  removeField(index: number): void {
    this.fields.removeAt(index);
  }

  addApprovalStep(): void {
    const step = this.fb.group({
      stepOrder: [this.approvalSteps.length + 1],
      stepName: ['', Validators.required],
      approver: ['', Validators.required],
      actionType: ['Approve', Validators.required]
    });

    this.approvalSteps.push(step);
  }

  removeApprovalStep(index: number): void {
    this.approvalSteps.removeAt(index);

    this.approvalSteps.controls.forEach((control, i) => {
      control.get('stepOrder')?.setValue(i + 1);
    });
  }

  submit(): void {

  if (this.form.invalid) {
    this.form.markAllAsTouched();
    return;
  }

  this.formsService.createForm(this.form.value).subscribe({
    next: (response) => {
      console.log('הטופס נשמר בהצלחה', response);
      alert('הטופס נשמר בהצלחה');
    },
    error: (error) => {
      console.error('שגיאה בשמירת הטופס', error);
      alert('אירעה שגיאה בשמירת הטופס');
    }
  });
}
}