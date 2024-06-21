import { Component, Input, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { MatDialog } from '@angular/material/dialog';
import { Project } from '../../services/projects.service';
import { MatTable } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Output, EventEmitter } from '@angular/core';
import { Device } from '../../services/devices.service';
import { MuiFormUpdateComponent } from '../mui-form-update/mui-form-update.component';
import { DevicesService } from '../../services/devices.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent {
  @Input() data: MatTableDataSource<Project> | MatTableDataSource<Device> =
    new MatTableDataSource<Project>([]) || new MatTableDataSource<Device>([]);
  @Input() columns: { key: string; header: string }[] = [];
  @Input() type: string = '';
  @Output() delete = new EventEmitter<number | string>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatTable) table!: MatTable<Project | Device>;
  @ViewChild(MatSort) sort!: MatSort;
  isLoading = true;
  dataSource:
    | MatTableDataSource<Project>
    | MatTableDataSource<Device>
    | undefined;

  ngAfterViewInit(): void {
    this.data.paginator = this.paginator;
    this.data.sort = this.sort;
    this.table.dataSource = this.data;
  }

  constructor(
    private dialog: MatDialog,
    private router: Router,
    private devicesService: DevicesService
  ) {}

  getDisplayedColumns(): string[] {
    if (this.router.url.includes('/device')) {
      const allColumns = [
        'checkbox',
        ...this.columns.map((column) => column.key),
      ];
      return this.router.url.includes('/projects')
        ? [...allColumns, 'actions']
        : allColumns;
    } else {
      const baseColumns = [
        'checkbox',
        ...this.columns.slice(0, 4).map((column) => column.key),
      ];
      return this.router.url.includes('/projects')
        ? [...baseColumns, 'actions']
        : baseColumns;
    }
  }
  getItemValue(item: Project, key: string): any {
    return item[key as keyof Project];
  }

  //checkbox'y
  selectAllChecked: boolean = false;

  toggleAllCheckbox(event: MatCheckboxChange) {
    this.selectAllChecked = event.checked;
    this.data.data.forEach(
      (element) => (element.checked = this.selectAllChecked)
    );
  }
  deleteRecord(id: number | string) {
    this.delete.emit(id);
  }

  toggleRowCheckbox(event: MatCheckboxChange, item: any) {
    item.checked = event.checked;
  }

  trackProject(index: number, project: Project): number {
    return project.id;
  }

  openDialogProject(idOrserialNumber: string): void {
    this.dialog.open(MuiFormUpdateComponent, {
      data: { id: idOrserialNumber },
      height: '90vh',
      width: '70vw',
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    if (this.data) {
      this.data.filter = filterValue.trim().toLowerCase();
    }
  }

  onUpdateClick(item: Project | Device): void {
    if ('id' in item) {
      this.openDialogProject(item.id.toString()); // dla projektu
    } else if ('imei' in item) {
    }
  }

  isProjectsRoute() {
    return this.router.url === '/projects';
  }

  onRowClick(item: any) {
    if (this.router.url.includes('/devices')) {
      if (item.imei) {
        this.devicesService.getDevicesDetails(item.imei);
      } else {
        console.error('SN is undefined');
      }
    }
  }
}
