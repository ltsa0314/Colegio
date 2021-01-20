import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReporteIndexComponent } from './reporte-index/reporte-index.component';
import { RouterModule, Routes } from '@angular/router';

const routesChlid: Routes = [
  {
    path: '',
    component: ReporteIndexComponent,
  },
];

@NgModule({
  declarations: [ReporteIndexComponent],
  imports: [CommonModule, RouterModule.forChild(routesChlid)],
})
export class ReporteModule {}
