import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AsignaturaIndexComponent } from './asignatura-index/asignatura-index.component';
import { AsignaturaFormComponent } from './asignatura-form/asignatura-form.component';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

const routesChlid: Routes = [
  {
    path: '',
    component: AsignaturaIndexComponent,
  },
  {
    path: 'nuevo',
    component: AsignaturaFormComponent,
  },
  {
    path: 'editar/:id',
    component: AsignaturaFormComponent,
  },
  {
    path: 'ver/:id',
    component: AsignaturaFormComponent,
  },
];

@NgModule({
  declarations: [AsignaturaIndexComponent, AsignaturaFormComponent],
  imports: [CommonModule, RouterModule.forChild(routesChlid),FormsModule],
})
export class AsignaturaModule {}
