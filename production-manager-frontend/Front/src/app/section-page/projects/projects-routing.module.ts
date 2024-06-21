import { NgModule } from '@angular/core';
import { Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ProjectsComponent } from './projects.component';

export const routes_projects: Routes = [
  { path: 'projects', component: ProjectsComponent },
  { path: '', redirectTo: 'projects', pathMatch: 'full' },
];

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class ProjectsRoutingModule {}
