import { Component, OnInit } from '@angular/core';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-mui-form',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    CommonModule,
    MatButton,
  ],
  templateUrl: './mui-form.component.html',
  styleUrl: './mui-form.component.scss',
})
export class MuiFormComponent implements OnInit {
  form: FormGroup = new FormGroup({});

  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<MuiFormComponent>
  ) {}
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: new FormControl('', [
        Validators.required,
        Validators.maxLength(100),
      ]),
      waterMeterConstFlowRate: new FormControl('', [
        Validators.required,
        Validators.maxLength(8),
        Validators.pattern('^[0-9,.]*'),
      ]),
      waterMeterDiameter: new FormControl(Number, [
        Validators.required,
        Validators.max(9999),
      ]),
      waterLeakAlarmCounterThreshold: new FormControl(Number, [
        Validators.required,
        Validators.max(9999),
      ]),
      waterLeakAlarmLowerThreshold: new FormControl(Number, [
        Validators.required,
        Validators.max(9999),
      ]),
      waterLeakAlarmInterval: new FormControl(Number, [
        Validators.required,
        Validators.max(9999),
      ]),
      suddenWaterLossAlarmCounterThreshold: new FormControl(Number, [
        Validators.required,
        Validators.max(9999),
      ]),
      suddenWaterLossAlarmLowerThreshold: new FormControl(Number, [
        Validators.required,
        Validators.max(9999),
      ]),
      suddenWaterLossAlarmInterval: new FormControl(Number, [
        Validators.required,
        Validators.max(9999),
      ]),
      waterMeterMeasuringRange: new FormControl(Number, [
        Validators.required,
        Validators.max(9999),
      ]),
    });
  }
  closeDialog() {
    this.dialogRef.close();
  }
  onSubmit(): void {
    if (this.form?.valid) {
      console.log('Poszło');
    } else {
      console.log('błąd');
    }
  }
}
