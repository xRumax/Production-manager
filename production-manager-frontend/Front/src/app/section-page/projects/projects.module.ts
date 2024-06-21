import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectsRoutingModule } from './projects-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule, ProjectsRoutingModule, FormsModule],
})
export class ProjectsModule {}
