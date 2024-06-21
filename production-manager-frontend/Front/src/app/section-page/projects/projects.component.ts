import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { FilterContentComponent } from '../../components/filter-content/filter-content.component';
import { MuiFormComponent } from '../../components/mui-form/mui-form.component';
import {
  ProjectsService,
  ProjectColumn,
  Project,
} from '../../services/projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss'],
})
export class ProjectsComponent implements OnInit {
  projectName: string = '';
  filteredProjects: any[] = [];
  dataSource: MatTableDataSource<Project>;
  projectColumn: ProjectColumn[] = [];
  formaddcomponent = MuiFormComponent;
  filtercontentcomponent = FilterContentComponent;
  dataLoaded: boolean = false;

  constructor(
    public dialog: MatDialog,
    private projectsService: ProjectsService,
    private changeDetector: ChangeDetectorRef
  ) {
    this.projectColumn = this.projectsService.projectColumn;
    this.dataSource = new MatTableDataSource<Project>(); // Initialize dataSource here
  }

  async ngOnInit(): Promise<void> {
    const projects = (await this.projectsService.getProjects()) || [];
    this.dataSource = new MatTableDataSource(projects);
    this.dataLoaded = true;
    this.changeDetector.detectChanges();
  }
  handleDelete(id: number | string) {
    this.projectsService.deleteProject(id);
  }
  getCheckedProjects(): number[] {
    const projects = this.dataSource.data.filter((project) => project.checked);
    // get only ids from projects
    const projectsIds = projects.map((project) => project.id);
    return projectsIds;
  }
  addProject(data: any): void {
    this.projectsService.addProject(data);
  }
  generateRaport(): void {
    this.projectsService.generateReport(this.getCheckedProjects());
  }
  openDialog(component: any): void {
    const dialogRef = this.dialog.open(component, {
      data: { caller: 'projects', add: this.addProject.bind(this) },
      height: '85vh',
      width: '70vw',
    });
  }

  type: string = 'project';
}
