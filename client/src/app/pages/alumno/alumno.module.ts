import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AlumnoIndexComponent } from './alumno-index/alumno-index.component';
import { AlumnoFormComponent } from './alumno-form/alumno-form.component';
import { FormsModule } from '@angular/forms';

const routesChlid: Routes = [
  {
    path: '',
    component: AlumnoIndexComponent,
  },
  {
    path: 'nuevo',
    component: AlumnoFormComponent,
  },
  {
    path: 'editar/:id',
    component: AlumnoFormComponent,
  },
  {
    path: 'ver/:id',
    component: AlumnoFormComponent,
  },
];

@NgModule({
  declarations: [AlumnoIndexComponent, AlumnoFormComponent],
  imports: [CommonModule, RouterModule.forChild(routesChlid), FormsModule],
})
export class AlumnoModule {}
