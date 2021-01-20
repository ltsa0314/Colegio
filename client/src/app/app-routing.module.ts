import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'alumnos',
    loadChildren: () =>
      import('./pages/alumno/alumno.module').then((m) => m.AlumnoModule),
  },
  {
    path: 'asignaturas',
    loadChildren: () =>
      import('./pages/asignatura/asignatura.module').then((m) => m.AsignaturaModule),
  },
  {
    path: 'profesores',
    loadChildren: () =>
      import('./pages/profesor/profesor.module').then((m) => m.ProfesorModule),
  },
  {
    path: 'reporte',
    loadChildren: () =>
      import('./pages/reporte/reporte.module').then((m) => m.ReporteModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
