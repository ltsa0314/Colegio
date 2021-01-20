import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfesorIndexComponent } from './profesor-index/profesor-index.component';
import { ProfesorFormComponent } from './profesor-form/profesor-form.component';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

const routesChlid: Routes = [
  {
    path: '',
    component: ProfesorIndexComponent,
  },
  {
    path: 'nuevo',
    component: ProfesorFormComponent,
  },
  {
    path: 'editar/:id',
    component: ProfesorFormComponent,
  },
  {
    path: 'ver/:id',
    component: ProfesorFormComponent,
  },
];

@NgModule({
  declarations: [ProfesorIndexComponent, ProfesorFormComponent],
  imports: [CommonModule, RouterModule.forChild(routesChlid),FormsModule],
})
export class ProfesorModule {}
