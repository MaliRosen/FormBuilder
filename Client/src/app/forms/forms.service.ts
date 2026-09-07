import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface FormField {
  label: string;
  fieldType: string;
}

export interface ApprovalStep {
  stepOrder: number;
  stepName: string;
  approver: string;
  actionType: string;
}

export interface CreateForm {
  name: string;
  createdBy: string;
  fields: FormField[];
  approvalSteps: ApprovalStep[];
}

@Injectable({
  providedIn: 'root'
})
export class FormsService {

  private apiUrl = 'https://localhost:7082/api/Forms';

  constructor(private http: HttpClient) {}

  createForm(form: CreateForm): Observable<any> {
    return this.http.post(this.apiUrl, form);
  }

  getForms(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getFormById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }
}