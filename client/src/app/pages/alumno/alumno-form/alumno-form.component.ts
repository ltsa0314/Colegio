import { AlumnoAsignaturaEntity } from './../../../models/alumnoAsignaturaEntity';
import { AlumnoAsignaturaService } from './../../../services/alumno-asignatura.service';
import { AsignaturaService } from 'src/app/services/asignatura.service';
import { AsignaturaEntity } from './../../../models/asignaturaEntity';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlumnoEntity } from '../../../models/alumnoEntity';
import { AlumnoService } from '../../../services/alumno.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-alumno-form',
  templateUrl: './alumno-form.component.html',
  styleUrls: ['./alumno-form.component.scss'],
})
export class AlumnoFormComponent implements OnInit, OnDestroy {
  title: string = '';
  isInfo: boolean = false;
  id: number = 0;
  modelo: AlumnoEntity = {};
  asignaturas: AsignaturaEntity[] = [];
  alumnoAsignaturas: AlumnoAsignaturaEntity[] = [];
  asignatura: string = '';
  ano: number = 0;
  calificacion: number = 0;
  private sub: any;

  constructor(
    private srvAlumno: AlumnoService,
    private srvAsignatur: AsignaturaService,
    private srvAlumnoAsignatura: AlumnoAsignaturaService,
    private router: Router,
    public route: ActivatedRoute
  ) {
    this.title = this.route.snapshot.url[0].path;
    this.isInfo = this.route.snapshot.url[0].path === 'ver' ? true : false;

    this.srvAsignatur
      .getAll()
      .subscribe((response) => (this.asignaturas = response));
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((params) => {
      this.id = +params['id'];
    });

    if (this.id != null)
      this.srvAlumno.getById(this.id).subscribe((result) => {
        this.modelo = result;
        this.loadAlumnoAsignaturas();
      });
  }

  loadAlumnoAsignaturas() {
    this.srvAlumnoAsignatura.getAll(this.modelo.id).subscribe((response) => {
      this.alumnoAsignaturas = response;
    });
  }
  getNombreAsignatura(id?:number){
    return this.asignaturas.find(x=> x.id == id)?.nombre;
  }
  onAsignar() {
    this.srvAlumnoAsignatura
      .insert({
        alumnoId: this.modelo.id,
        asignaturaId: parseInt(this.asignatura),
        ano: this.ano,
        calificacionFinal: this.calificacion,
      })
      .subscribe(
        () => {

          Swal.fire({
            icon: 'success',
            title: 'Operacion Exitosa',
            text: 'Se Asigno la materia',
          }).then(()=> this.loadAlumnoAsignaturas());
        },
        (error) => {
          console.log(error);
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: JSON.stringify(error.message ? error.error : error.message),
          });
        }
      );
  }
  onSave() {
    if (this.title == 'nuevo') {
      this.srvAlumno.insert(this.modelo).subscribe(
        () => this.router.navigate(['alumnos']),
        (error) => {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: JSON.stringify(error.message),
          });
        }
      );
    }
    if (this.title == 'editar') {
      this.srvAlumno.update(this.modelo).subscribe(
        () => this.router.navigate(['alumnos']),
        (error) => {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: JSON.stringify(error.message),
          });
        }
      );
    }
  }
  onCancel() {
    this.router.navigate(['alumnos']);
  }
  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
