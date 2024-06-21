import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectsService, Project } from '../../services/projects.service';
import { MatDialog } from '@angular/material/dialog';
import { MuiFormUpdateComponent } from '../../components/mui-form-update/mui-form-update.component';
@Component({
  selector: 'app-projects-details',
  templateUrl: './project-details.component.html',
  styleUrl: './project-details.component.scss',
})
export class ProjectDetailsComponent implements OnInit {
  id: string | number | null = 0;
  project: Project = {
    id: 0,
    name: '',
    waterMeterConstFlowRate: 0,
    waterMeterDiameter: 0,
    waterLeakAlarmCounterThreshold: 0,
    waterLeakAlarmLowerThreshold: 0,
    waterLeakAlarmInterval: 0,
    suddenWaterLossAlarmCounterThreshold: 0,
    suddenWaterLossAlarmLowerThreshold: 0,
    suddenWaterLossAlarmInterval: 0,
    waterMeterMeasuringRange: 0,
    checked: false,
  };

  constructor(
    private route: ActivatedRoute,
    private projectsService: ProjectsService,
    private dialog: MatDialog
  ) {}

  openDialogProject(id: string): void {
    this.dialog.open(MuiFormUpdateComponent, {
      data: { id: id },
      height: '90vh',
      width: '70vw',
    });
  }
  onUpdateClick(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.id = id;
    this.openDialogProject(id.toString()); // dla projektu
  }

  async ngOnInit(): Promise<void> {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.id = id;
    this.project = await this.projectsService.getProjectsDetails(id);
  }
}
