import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { DevicesComponent } from './devices.component';

export const routes_devices: Routes = [
  { path: 'devices', component: DevicesComponent },
];

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class DevicesRoutingModule {}
