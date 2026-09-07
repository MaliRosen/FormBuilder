import { Routes } from '@angular/router';
import { FormCreateComponent } from './forms/form-create/form-create.component';
import { FormsListComponent } from './forms/forms-list/forms-list.component';
import { FormDetailsComponent } from './forms/form-details/form-details.component';
export const routes: Routes = [
  {
    path: '',
    redirectTo: 'forms',
    pathMatch: 'full'
  },
  {
    path: 'forms',
    component: FormsListComponent
  },
  {
    path: 'forms/new',
    component: FormCreateComponent
  },
  {
  path: 'forms/:id',
  component: FormDetailsComponent
}
];