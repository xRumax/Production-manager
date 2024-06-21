import { Component, Inject, OnInit } from '@angular/core';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ProjectsService } from '../../services/projects.service';

@Component({
  selector: 'app-mui-form-update',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    CommonModule,
    MatButton,
  ],
  templateUrl: './mui-form-update.component.html',
  styleUrl: './mui-form-update.component.scss',
})
export class MuiFormUpdateComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<MuiFormUpdateComponent>,
    private projectsService: ProjectsService,
    @Inject(MAT_DIALOG_DATA) public ref: any
  ) {
    this.form = this.formBuilder.group({});
  }

  ngOnInit(): void {
    const elementId = this.ref.id;

    this.form = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      waterMeterConstFlowRate: [
        '',
        [
          Validators.required,
          Validators.maxLength(8),
          Validators.pattern('^[0-9,.]*'),
        ],
      ],
      waterMeterDiameter: [
        '',
        [
          Validators.required,
          Validators.maxLength(4),
          Validators.pattern('^[0-9]*$'),
        ],
      ],
      waterLeakAlarmCounterThreshold: [
        '',
        [
          Validators.required,
          Validators.maxLength(4),
          Validators.pattern('^[0-9]*'),
        ],
      ],
      waterLeakAlarmLowerThreshold: [
        '',
        [
          Validators.required,
          Validators.maxLength(4),
          Validators.pattern('^[0-9]*'),
        ],
      ],
      waterLeakAlarmInterval: [
        '',
        [
          Validators.required,
          Validators.maxLength(4),
          Validators.pattern('^[0-9]*'),
        ],
      ],
      suddenWaterLossAlarmCounterThreshold: [
        '',
        [
          Validators.required,
          Validators.maxLength(4),
          Validators.pattern('^[0-9]*'),
        ],
      ],
      suddenWaterLossAlarmLowerThreshold: [
        '',
        [
          Validators.required,
          Validators.maxLength(4),
          Validators.pattern('^[0-9]*'),
        ],
      ],
      suddenWaterLossAlarmInterval: [
        '',
        [
          Validators.required,
          Validators.maxLength(4),
          Validators.pattern('^[0-9]*'),
        ],
      ],
      waterMeterMeasuringRange: [
        '',
        [
          Validators.required,
          Validators.maxLength(4),
          Validators.pattern('^[0-9]*'),
        ],
      ],
    });
    this.projectsService.getUpdateForm(elementId).then((data: any) => {
      this.form.patchValue(data);
    });
  }
  closeDialog() {
    this.dialogRef.close();
  }
  onSubmit(): void {
    const waterMeterConstFlowRate = this.form.get('waterMeterConstFlowRate');
    if (waterMeterConstFlowRate?.value.toString().includes(',')) {
      waterMeterConstFlowRate.setValue(
        waterMeterConstFlowRate.value.toString().replace(',', '.')
      );
    }

    if (this.form.valid) {
      this.projectsService.update(this.ref.id, this.form.value).then(() => {
        this.dialogRef.close();
      });
    }
  }
}
