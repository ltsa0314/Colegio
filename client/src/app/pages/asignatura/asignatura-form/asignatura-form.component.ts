import { AsignaturaEntity } from './../../../models/asignaturaEntity';
import { Component, OnInit } from '@angular/core';
import { AsignaturaService } from 'src/app/services/asignatura.service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-asignatura-form',
  templateUrl: './asignatura-form.component.html',
  styleUrls: ['./asignatura-form.component.scss'],
})
export class AsignaturaFormComponent implements OnInit {
  title: string = '';
  isInfo: boolean = false;
  id: number = 0;
  modelo: AsignaturaEntity = {};
  private sub: any;

  constructor(
    private srvAsignatura: AsignaturaService,
    private router: Router,
    public route: ActivatedRoute
  ) {
    this.title = this.route.snapshot.url[0].path;
    this.isInfo = this.route.snapshot.url[0].path === 'ver' ? true : false;
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((params) => {
      this.id = +params['id'];
    });
    if (this.id != null)
      this.srvAsignatura
        .getById(this.id)
        .subscribe((result) => (this.modelo = result));
  }
  onSave() {
    if (this.title == 'nuevo') {
      this.srvAsignatura
        .insert(this.modelo)
        .subscribe(() => this.router.navigate(['asignaturas']),(error)=>{
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: JSON.stringify(error.message)
          })

        });
    }
    if (this.title == 'editar') {
      this.srvAsignatura
        .update(this.modelo)
        .subscribe(() => this.router.navigate(['asignaturas']),(error)=>{
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: JSON.stringify(error.message)
          })

        });
    }
  }
  onCancel() {
    this.router.navigate(['asignaturas']);
  }
  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
