import { AlumnoEntity } from './../../../models/alumnoEntity';
import { AlumnoService } from './../../../services/alumno.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-alumno-index',
  templateUrl: './alumno-index.component.html',
  styleUrls: ['./alumno-index.component.scss'],
})
export class AlumnoIndexComponent implements OnInit {
  data: AlumnoEntity[] = [];

  constructor(public srvAlumno: AlumnoService, private router: Router) {}

  loadData() {
    this.data = [];

    this.srvAlumno.getAll().subscribe(
      (response) => (this.data = response),
      (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: JSON.stringify(error.message),
        });
      }
    );
  }
  ngOnInit(): void {
    this.loadData();
  }
  onNew() {
    this.router.navigate([this.router.routerState.snapshot.url + '/nuevo']);
  }

  onView(id: any) {
    this.router.navigate([this.router.routerState.snapshot.url + '/ver/' + id]);
  }
  onEdit(id: any) {
    this.router.navigate([
      this.router.routerState.snapshot.url + '/editar/' + id,
    ]);
  }
  onDelete(id: any) {
    Swal.fire({
      title: 'Eliminar!',
      text: 'Seguro que desea eliminar el registro',
      icon: 'warning',
      confirmButtonText: 'Si',
    }).then((result) => {
      if (result.isConfirmed) {
        this.srvAlumno.delete(id).subscribe(() => this.loadData(),
        (error) => {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: JSON.stringify(error.message ? error.error : error.message),
          });
        });
      }
    });
  }
}
