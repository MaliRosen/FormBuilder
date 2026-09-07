import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsStore } from '../forms.store';

@Component({
  selector: 'app-forms-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './forms-list.component.html',
  styleUrl: './forms-list.component.css'
})
export class FormsListComponent implements OnInit {

  constructor(public formsStore: FormsStore) {}

  ngOnInit(): void {
    this.formsStore.loadForms();
  }
}