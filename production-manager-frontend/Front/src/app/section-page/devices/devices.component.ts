import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { FilterContentComponent } from '../../components/filter-content/filter-content.component';
import {
  DevicesService,
  DeviceColumn,
  Device,
} from '../../services/devices.service';
import { MuiFormDevicesComponent } from '../../components/mui-form-devices/mui-form-devices.component';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss'],
})
export class DevicesComponent implements OnInit {
  deviceName: string = '';
  filteredDevices: any[] = [];
  dataSource: MatTableDataSource<Device>;
  deviceColumn: DeviceColumn[] = [];
  formaddcomponent = MuiFormDevicesComponent;
  filtercontentcomponent = FilterContentComponent;
  dataLoaded: boolean = false;

  constructor(
    public dialog: MatDialog,
    private devicesService: DevicesService,
    private changeDetector: ChangeDetectorRef
  ) {
    this.deviceColumn = this.devicesService.deviceColumn;
    this.dataSource = new MatTableDataSource<Device>();
  }

  async ngOnInit(): Promise<void> {
    const devices = (await this.devicesService.getDevices()) || [];
    this.dataSource = new MatTableDataSource(devices);
    this.dataLoaded = true;
    this.changeDetector.detectChanges();
  }
  handleDelete(id: number | string) {
    this.devicesService.deleteDevice(id);
  }
  addDevice(data: any): void {
    this.devicesService.addDevice(data);
  }
  getCheckedDevices(): string[] {
    const devices = this.dataSource.data.filter((device) => device.checked);

    const devicesIds = devices.map((device) => device.imei);
    return devicesIds;
  }
  generateRaport(): void {
    this.devicesService.generateReport(this.getCheckedDevices());
  }
  openDialog(component: any): void {
    this.dialog.open(component, {
      data: {
        add: this.addDevice.bind(this.devicesService),
      },
      height: '80vh',
      width: '70vw',
    });
  }

  type: string = 'device';
}
