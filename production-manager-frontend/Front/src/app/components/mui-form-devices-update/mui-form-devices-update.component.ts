import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { DevicesService } from '../../services/devices.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';
@Component({
  selector: 'app-mui-form-devices-update',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './mui-form-devices-update.component.html',
  styleUrl: './mui-form-devices-update.component.scss',
})
export class MuiFormDevicesUpdateComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  constructor(
    @Inject(MAT_DIALOG_DATA) public ref: any,
    private formBilder: FormBuilder,
    private dialogRef: MatDialogRef<MuiFormDevicesUpdateComponent>,
    private devicesService: DevicesService
  ) {}
  ngOnInit(): void {
    const elementImei = this.ref.imei;
    this.form = this.formBilder.group({
      imei: new FormControl('', Validators.required),
      projectName: new FormControl(
        { value: '', disabled: true },
        Validators.required
      ),
      orderNumber: new FormControl(
        { value: '', disabled: true },
        Validators.required
      ),
      ccid: new FormControl({ value: '', disabled: true }, Validators.required),
      model: new FormControl(
        { value: '', disabled: true },
        Validators.required
      ),
      serialNumber: new FormControl(
        { value: '', disabled: true },
        Validators.required
      ),
      firmwareVersion: new FormControl(
        { value: '', disabled: true },
        Validators.required
      ),
      esi: new FormControl({ value: '', disabled: true }, Validators.required),
    });
    this.devicesService.getUpdateForm(elementImei).then((data: any) => {
      this.form.patchValue(data);
    });
  }
  closeDialog() {
    this.dialogRef.close();
  }
  onSubmit(): void {
    this.devicesService
      .update(this.ref.imei, this.form.value)
      .then(() => this.dialogRef.close());
  }
}
