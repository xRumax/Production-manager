import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AppComponent } from './app.component';
import { DevicesComponent } from './section-page/devices/devices.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { NavbarComponent } from './navbar/navbar.component';
import { ProjectsComponent } from './section-page/projects/projects.component';
import { TableModule } from './components/table/table.module';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { FilterContentComponent } from './components/filter-content/filter-content.component';
import { ProjectDetailsComponent } from './section-page/project-details/project-details.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatToolbar } from '@angular/material/toolbar';
import { DeviceDetailsComponent } from './section-page/device-details/device-details.component';

@NgModule({
  declarations: [
    FilterContentComponent,
    ProjectsComponent,
    AppComponent,
    DevicesComponent,
    NavbarComponent,
    ProjectDetailsComponent,
    DeviceDetailsComponent,
  ],
  imports: [
    BrowserModule,
    TableModule,
    RouterModule.forRoot([]),
    AppRoutingModule,
    MatCheckboxModule,
    MatSortModule,
    FormsModule,
    MatButtonModule,
    MatDialogModule,
    ReactiveFormsModule,

    MatSnackBarModule,
    MatTableModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatToolbar,
  ],
  providers: [provideAnimationsAsync()],
  bootstrap: [AppComponent],
})
export class AppModule {}
