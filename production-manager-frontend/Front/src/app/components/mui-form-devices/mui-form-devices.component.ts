import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-mui-form-devices',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatSelectModule, ReactiveFormsModule, CommonModule, MatButton],
  templateUrl: './mui-form-devices.component.html',
  styleUrl: './mui-form-devices.component.scss'
})
export class MuiFormDevicesComponent implements OnInit {
  form: FormGroup = new FormGroup({})
  constructor(private formBilder: FormBuilder, private dialogRef: MatDialogRef<MuiFormDevicesComponent>) { }
  ngOnInit(): void {
    this.form = this.formBilder.group({
      IMEI: new FormControl('', Validators.required),
      ProjectName: new FormControl('', Validators.required),
      OrderNumber: new FormControl('', Validators.required),
      CCID: new FormControl('', Validators.required),
      Model: new FormControl('', Validators.required),
      SerialNumber: new FormControl('', Validators.required),
      FirmwareVersion: new FormControl('', Validators.required),
      ESI: new FormControl('', Validators.required)
    })
  }
  closeDialog() {
    this.dialogRef.close()
  }
  onSubmit(): void {
    if (this.form?.valid) {
      console.log('Poszło')
    }
    else {
      console.log('błąd')
    }
  }
}
