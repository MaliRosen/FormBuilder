import { Injectable, signal } from '@angular/core';
import { FormsService } from './forms.service';

@Injectable({
  providedIn: 'root'
})
export class FormsStore {

  private readonly _forms = signal<any[]>([]);
  private readonly _loading = signal(false);

  readonly forms = this._forms.asReadonly();
  readonly loading = this._loading.asReadonly();

  constructor(private formsService: FormsService) {}

  loadForms(): void {

    this._loading.set(true);

    this.formsService.getForms().subscribe({
      next: (forms) => {
        this._forms.set(forms);
        this._loading.set(false);
      },
      error: (error) => {
        console.error(error);
        this._loading.set(false);
      }
    });
  }

  addForm(form: any): void {
    this._forms.update(forms => [...forms, form]);
  }
}