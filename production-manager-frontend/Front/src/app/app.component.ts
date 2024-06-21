import { Component } from '@angular/core';
export interface FormField {
  type: string;
  name: string;
  id: string;
  placeholder: string;
  pattern?: string;
  min?: string;
  max?: string;
  title: string;
}
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'Front';
}
