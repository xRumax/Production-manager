import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DevicesService, Device } from '../../services/devices.service';

@Component({
  selector: 'app-device-details',
  templateUrl: './device-details.component.html',
  styleUrl: './device-details.component.scss',
})
export class DeviceDetailsComponent {
  imei: string | number | null = 0;
  device: Device = {
    imei: '',
    projectName: '',
    orderNumber: '',
    ccid: '',
    model: '',
    serialNumber: '',
    firmwareVersion: '',
    esiThresholdChannel0: '',
    createdAt: '',
    checked: false,
  };

  constructor(
    private route: ActivatedRoute,
    private devicesService: DevicesService
  ) {}

  async ngOnInit(): Promise<void> {
    const imei = String(this.route.snapshot.paramMap.get('imei'));
    this.imei = imei;
    this.device = await this.devicesService.getDevicesDetails(imei);
  }
}
