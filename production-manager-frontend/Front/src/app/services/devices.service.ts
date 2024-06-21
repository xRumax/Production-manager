import { Injectable } from '@angular/core';
import axios from 'axios';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormField } from '../app.component';
import { Environment } from '../../environments/environment';
import download from 'downloadjs';
export interface Device {
  imei: string;
  projectName: string;
  orderNumber: string;
  ccid: string;
  model: string;
  serialNumber: string;
  firmwareVersion: string;
  esiThresholdChannel0: string;
  checked: boolean;
  createdAt: string;
}

export interface DeviceColumn {
  key: keyof Device;
  header: string;
}
export const fields_devices: FormField[] = [
  {
    id: 'imei',
    title: 'IMEI',
    type: 'text',
    name: 'imei',
    placeholder: 'Podaj IMEI',
  },
  {
    id: 'projectName',
    title: 'Project Name',
    type: 'text',
    name: 'projectName',
    placeholder: 'Podaj Project Name',
  },
  {
    id: 'orderNumber',
    title: 'Order Number',
    type: 'text',
    name: 'orderNumber',
    placeholder: 'Podaj Order Number',
  },
  {
    id: 'ccid',
    title: 'CCID',
    type: 'text',
    name: 'ccid',
    placeholder: 'Podaj CCID',
  },
  {
    id: 'model',
    title: 'Model',
    type: 'text',
    name: 'model',
    placeholder: 'Podaj Model',
  },
  {
    id: 'serialNumber',
    title: 'Serial Number',
    type: 'text',
    name: 'serialNumber',
    placeholder: 'Podaj Serial Number',
  },
  {
    id: 'firmwareVersion',
    title: 'Firmware Version',
    type: 'text',
    name: 'firmwareVersion',
    placeholder: 'Podaj Firmware Version',
  },
  {
    id: 'esiThresholdChannel0',
    title: 'ESI Threshold Channel 0',
    type: 'text',
    name: 'esiThresholdChannel0',
    placeholder: 'Podaj ESI Threshold Channel 0',
  },
];
@Injectable({
  providedIn: 'root',
})
export class DevicesService {
  deviceColumn: DeviceColumn[] = [
    { key: 'imei', header: 'IMEI' },
    { key: 'projectName', header: 'Nazwa projektu' },
    { key: 'orderNumber', header: 'Numer zamówienia' },
    { key: 'ccid', header: 'CCID' },
    { key: 'model', header: 'Model' },
    { key: 'serialNumber', header: 'Numer seryjny' },
    { key: 'firmwareVersion', header: 'Wersja oprogramowania' },
    { key: 'esiThresholdChannel0', header: 'Kanał progowy ESI 0' },
  ];

  constructor(private snackBar: MatSnackBar, private envService: Environment) {}

  getDevicesDetails(imei: number | string): Promise<Device> {
    return axios
      .get(`${this.envService.base_url}/Report/${imei}`)
      .then((response) => response.data.data as Device)
      .catch((error) => {
        console.error('Error fetching device details:', error);
        this.snackBar.open(
          'Błąd podczas pobierania szczegółów urządzenia, spróbuj ponownie.',
          'Zamknij',
          {
            duration: 5000,
          }
        );
        throw error;
      });
  }

  getDevices(): Promise<Device[]> {
    return axios
      .get(`${this.envService.base_url}/Report`, {
        params: {
          PageIndex: -1,
        },
      })
      .then((response) => {
        return response.data.data.map((device: Device) => ({
          ...device,
          ccid: device.ccid || 'Brak',
          checked: false,
        }));
      })
      .catch((error) => {
        console.error('Error fetching device details:', error);
        this.snackBar.open(
          'Błąd podczas pobierania urządzeń, spróbuj ponownie',
          'Zamknij',
          {
            duration: 5000,
          }
        );
        throw error;
      });
  }
  getUpdateForm(deviceImei: string | number): Promise<Device> {
    return axios
      .get(`${this.envService.base_url}/Report/${deviceImei}`)
      .then((response) => {
        return response.data.data as Device;
      })
      .catch((error) => {
        console.error('Error fetching project data:', error);
        this.snackBar.open(
          'Błąd podczas pobierania danych urządzenia, spróbuj ponownie',
          'Zamknij',
          {
            duration: 5000,
          }
        );
        throw error;
      });
  }

  async update(id: number, data: any): Promise<any> {
    try {
      const response = await axios.put(
        `${this.envService.base_url}/Report/${id}`,
        data
      );
      this.snackBar.open('Urządzenie zaktualizowano poprawnie', 'Zamknij', {
        duration: 5000,
      });
      setTimeout(() => {
        window.location.reload();
      }, 500);

      return response.data;
    } catch (error) {
      console.error('Error updating device:', error);
      this.snackBar.open('Błąd aktualizacji spróbuj ponownie', 'Close', {
        duration: 5000,
      });
      throw error;
    }
  }

  async deleteDevice(id: number | string): Promise<any> {
    try {
      const deviceDetails = await this.getDevicesDetails(id);
      const createdAt = deviceDetails.createdAt;

      const response = await axios.delete(
        `${this.envService.base_url}/Report/${id}/${createdAt}`
      );
      this.snackBar.open('Urządzenie usunięty', 'Zamknij', {
        duration: 5000,
      });
      setTimeout(() => {
        window.location.reload();
      }, 1000);

      return response.data;
    } catch (error) {
      console.error('Error deleting device:', error);
      this.snackBar.open('Błąd podczas usuwania urządzenia', 'Zamknij', {
        duration: 5000,
      });
      throw error;
    }
  }
  addDevice(data: any): Promise<any> {
    return axios
      .post(`${this.envService.base_url}/Report`, data)
      .then((response) => {
        this.snackBar.open('Urządzdnie dodane', 'Zamknij', {
          duration: 5000,
        });
        setTimeout(() => {
          window.location.reload();
        }, 500);

        return response.data;
      })
      .catch((error) => {
        console.error('Error adding project:', error);
        this.snackBar.open('Błąd podczas dodawania urządzenia', 'Zamknij', {
          duration: 5000,
        });
        throw error;
      });
  }
  generateReport(data: any): Promise<any> {
    const params = data.map((id: string) => `List=${id}`).join('&');
    return axios
      .get(`${this.envService.base_url}/Report/ExcelReport?${params}`, {
        responseType: 'blob',
      })
      .then((response) => {
        this.snackBar.open('Raport wygenerowany', 'Zamknij', {
          duration: 5000,
        });
        const fileName = `report_${data.join('_')}.xlsx`;
        download(
          response.data,
          fileName,
          'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
        );
        return response.data;
      })
      .catch((error) => {
        console.error('Error generating report:', error);
        this.snackBar.open('Błąd podczas generowania raportu', 'Zamknij', {
          duration: 5000,
        });
        throw error;
      });
  }
}
