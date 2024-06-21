import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectDetailsComponent } from './section-page/project-details/project-details.component';
import { DeviceDetailsComponent } from './section-page/device-details/device-details.component';

//routes
import { routes_projects } from './section-page/projects/projects-routing.module';
import { routes_devices } from './section-page/devices/devices-routing.module';

const routes: Routes = [
  { path: 'project/:id', component: ProjectDetailsComponent },
  //{ path: 'device/:imei', component: DeviceDetailsComponent },
  ...routes_projects,
  ...routes_devices,
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
