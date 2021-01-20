import { Component, OnInit } from '@angular/core';
import { ReporteCalificacionesEntity } from 'src/app/models/reporteCalificacionesEntity';
import { AlumnoService } from 'src/app/services/alumno.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-reporte-index',
  templateUrl: './reporte-index.component.html',
  styleUrls: ['./reporte-index.component.scss'],
})
export class ReporteIndexComponent implements OnInit {
  data: ReporteCalificacionesEntity[] = [];
  constructor(public srvAlumno: AlumnoService) {}

  ngOnInit(): void {
    this.srvAlumno.getReport().subscribe((response) => (this.data = response),(error)=>{
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: JSON.stringify(error.message)
      })

    });
  }
}
