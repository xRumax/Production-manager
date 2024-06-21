import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {
  ProjectsService,
  Project,
  ProjectColumn,
} from '../../services/projects.service';

@Component({
  selector: 'app-filter-content',
  templateUrl: './filter-content.component.html',
  styleUrl: './filter-content.component.scss',
})
export class FilterContentComponent {
  projectName: string = '';
  filteredProjects: Project[] = [];
  type: string = 'projekt';
  projects: Project[] = [];
  projectColumn: ProjectColumn[] = [];
  searchClicked: boolean = false;

  constructor(
    private projectsService: ProjectsService,
    public dialogRef: MatDialogRef<FilterContentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.projects = [];
    this.projectColumn = this.projectsService.projectColumn;
  }

  closeDialog() {
    this.dialogRef.close();
  }

  async ngOnInit(): Promise<void> {
    this.projects = await this.projectsService.getProjects();
    this.filteredProjects = this.projects;
  }

  search() {
    this.searchClicked = true;
    if (this.projectName.trim() === '') {
      this.filteredProjects = this.projects;
    } else {
      this.filteredProjects = this.projects.filter((project) =>
        project.name
          .toLowerCase()
          .includes(this.projectName.trim().toLowerCase())
      );
    }
  }
}
