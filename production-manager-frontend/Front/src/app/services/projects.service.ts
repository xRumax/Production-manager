import { Injectable } from '@angular/core';
import axios from 'axios';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormField } from '../app.component';
import { Environment } from '../../environments/environment';
import download from 'downloadjs';

export interface Project {
  id: number;
  name: string;
  waterMeterConstFlowRate: number;
  waterMeterDiameter: number;
  waterLeakAlarmCounterThreshold: number;
  waterLeakAlarmLowerThreshold: number;
  waterLeakAlarmInterval: number;
  suddenWaterLossAlarmCounterThreshold: number;
  suddenWaterLossAlarmLowerThreshold: number;
  suddenWaterLossAlarmInterval: number;
  waterMeterMeasuringRange: number;
  checked: boolean;
}
export const fields_projects: FormField[] = [
  {
    type: 'text',
    name: 'name',
    id: 'name',
    placeholder: 'Podaj nazwę',
    title: 'Ilość znaków: 1-100',
    pattern: '[A-Z][a-z]{1,100}',
  },
  {
    type: 'text',
    name: 'water-meter-const-flow-rate',
    id: 'water-meter-const-flow-rate',
    placeholder: 'Podaj przepływ wodomierza',
    title: 'Wymagana ilość dlugości cyfr: 8',
    pattern: '^d{8}(?:.d+)?$',
  },
  {
    type: 'number',
    name: 'water-meter-diameter',
    id: 'water-meter-diameter',
    placeholder: 'Podaj średnice wodomierza',
    title: 'Tylko liczby całkowite max: 4',
    max: '9999',
    min: '1',
  },
  {
    type: 'number',
    name: 'water-leak-alarm-couter-threshold',
    id: 'water-leak-alarm-couter-threshold',
    placeholder: 'Podaj próg wystąpienia alarmu wycieku wody',
    title: 'Tylko liczby całkowite max: 4',
    max: '9999',
    min: '1',
  },
  {
    type: 'number',
    name: 'water-leak-alarm-lower-threshold',
    id: 'water-leak-alarm-lower-threshold',
    placeholder: 'Podaj próg alarmowy wycieku wody',
    title: 'Tylko liczby całkowite max: 4',
    max: '9999',
    min: '1',
  },
  {
    type: 'number',
    name: 'water-leak-alarm-interval',
    id: 'water-leak-alarm-interval',
    placeholder: 'Podaj interwał sprawdzający alarm wycieku wody',
    title: 'Tylko liczby całkowite max: 4',
    max: '9999',
    min: '1',
  },
  {
    type: 'number',
    name: 'sudden-water-loss-alarm-counter-threshold',
    id: 'sudden-water-loss-alarm-counter-threshold',
    placeholder: 'Podaj próg wystąpień nagłej utraty wody',
    title: 'Tylko liczby całkowite max: 4',
    max: '9999',
    min: '1',
  },
  {
    type: 'number',
    name: 'sudden-water-loss-alarm-lower-threshold',
    id: 'sudden-water-loss-alarm-lower-threshold',
    placeholder: 'Podaj próg alarmowy nagłej utraty wody',
    title: 'Tylko liczby całkowite max: 4',
    max: '9999',
    min: '1',
  },
  {
    type: 'number',
    name: 'sudden-water-loss-alarm-interval',
    id: 'sudden-water-loss-alarm-interval',
    placeholder: 'Podaj interwał sprawdzający nagłą utratę wody',
    title: 'Tylko liczby całkowite max: 4',
    max: '9999',
    min: '1',
  },
  {
    type: 'number',
    name: 'water-meter-measuring-range',
    id: 'water-meter-measuring-range',
    placeholder: 'Podaj zakres pomiarowy wodomierza',
    title: 'Tylko liczby całkowite max: 4',
    max: '9999',
    min: '1',
  },
];

export interface ProjectColumn {
  key: keyof Project;
  header: string;
}
@Injectable({
  providedIn: 'root',
})
export class ProjectsService {
  projectColumn: ProjectColumn[] = [
    { key: 'id', header: 'Id' },
    { key: 'name', header: 'Nazwa projektu' },
    { key: 'waterMeterConstFlowRate', header: 'Przepływ wodomierza' },
    { key: 'waterMeterDiameter', header: 'Średnica wodomierza' },
    {
      key: 'waterLeakAlarmCounterThreshold',
      header: 'Próg alarmowy wycieku wody',
    },
    {
      key: 'waterLeakAlarmLowerThreshold',
      header: 'Dolny próg alarmowy wycieku wody',
    },
    { key: 'waterLeakAlarmInterval', header: 'Interwał alarmowy wycieku wody' },
    {
      key: 'suddenWaterLossAlarmCounterThreshold',
      header: 'Próg alarmowy nagłej utraty wody',
    },
    {
      key: 'suddenWaterLossAlarmLowerThreshold',
      header: 'Dolny próg alarmowy nagłej utraty wody',
    },
    {
      key: 'suddenWaterLossAlarmInterval',
      header: 'Interwał alarmowy nagłej utraty wody',
    },
    { key: 'waterMeterMeasuringRange', header: 'Zakres pomiarowy wodomierza' },
  ];

  constructor(private snackBar: MatSnackBar, private envService: Environment) {}

  getProjectsDetails(id: number): Promise<Project> {
    return axios
      .get(`${this.envService.base_url}/Project/${id}`)
      .then((response) => response.data.data as Project) // Return the project data directly
      .catch((error) => {
        console.error('Error fetching project details:', error);
        this.snackBar.open(
          'Błąd podczas pobierania szczegółów projektu, spróbuj ponownie.',
          'Zamknij',
          {
            duration: 5000,
          }
        );
        throw error; // Re-throw the error if you want to catch it again in the component
      });
  }

  getProjects(): Promise<Project[]> {
    return axios
      .get(`${this.envService.base_url}/Project`, {
        params: {
          PageIndex: -1,
        },
      })
      .then((response) => {
        return response.data.data.map((project: Project) => ({
          ...project,
          checked: false,
        }));
      })
      .catch((error) => {
        console.error('Error fetching project details:', error);
        this.snackBar.open(
          'Błąd podczas pobierania projektów, spróbuj ponownie',
          'Zamknij',
          {
            duration: 5000,
          }
        );
        throw error; // Re-throw the error if you want to catch it again in the component
      });
  }

  getUpdateForm(projectId: number): Promise<Project> {
    return axios
      .get(`${this.envService.base_url}/Project/${projectId}`)
      .then((response) => {
        return response.data.data;
      })
      .catch((error) => {
        console.error('Error fetching project data:', error);
        throw error;
      });
  }

  async update(id: number, data: any): Promise<any> {
    try {
      const response = await axios.put(
        `${this.envService.base_url}/Project/${id}`,
        data
      );
      this.snackBar.open('Project updated successfully', 'Close', {
        duration: 5000,
      });
      setTimeout(() => {
        window.location.reload();
      }, 500);

      return response.data;
    } catch (error) {
      console.error('Error updating project:', error);
      this.snackBar.open('Błąd podczas aktualizacji', 'Zamknij', {
        duration: 5000,
      });
      throw error;
    }
  }

  async deleteProject(id: number | string): Promise<any> {
    try {
      const response = await axios.delete(
        `${this.envService.base_url}/Project/${id}`
      );
      this.snackBar.open('Projekt usunięty', 'Zamknij', {
        duration: 5000,
      });
      setTimeout(() => {
        window.location.reload();
      }, 1000);

      return response.data;
    } catch (error) {
      console.error('Error deleting project:', error);
      this.snackBar.open('Błąd podczas usuwania projektu', 'Zamknij', {
        duration: 5000,
      });
      throw error;
    }
  }
  addProject(data: any): Promise<any> {
    return axios
      .post(`${this.envService.base_url}/Project`, data)
      .then((response) => {
        this.snackBar.open('Projekt dodany', 'Zamknij', {
          duration: 5000,
        });
        setTimeout(() => {
          window.location.reload();
        }, 500);

        return response.data;
      })
      .catch((error) => {
        console.error('Error adding project:', error);
        this.snackBar.open('Błąd podczas dodawania projektu', 'Zamknij', {
          duration: 5000,
        });
        throw error;
      });
  }
  generateReport(data: any): Promise<any> {
    const params = data.map((id: number) => `List=${id}`).join('&');
    return axios
      .get(`${this.envService.base_url}/Project/ExcelReport?${params}`, {
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
