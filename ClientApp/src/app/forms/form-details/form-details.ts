import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormsService } from '../forms.service';

@Component({
  selector: 'app-form-details',
  templateUrl: './form-details.component.html',
  styleUrl: './form-details.component.css'
})
export class FormDetailsComponent implements OnInit {

  form: any = null;
  loading = false;
  error = '';

  constructor(
    private route: ActivatedRoute,
    private formsService: FormsService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id) {
      this.error = 'מזהה טופס לא תקין';
      return;
    }

    this.loadForm(id);
  }

  loadForm(id: number): void {
    this.loading = true;

    this.formsService.getFormById(id).subscribe({
      next: (result) => {
        this.form = result;
        this.loading = false;
      },
      error: (error) => {
        console.error(error);
        this.error = 'לא ניתן לטעון את הטופס';
        this.loading = false;
      }
    });
  }
}