import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfesorEntity } from 'src/app/models/profesorEntity';
import { ProfesorService } from 'src/app/services/profesor.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-profesor-form',
  templateUrl: './profesor-form.component.html',
  styleUrls: ['./profesor-form.component.scss'],
})
export class ProfesorFormComponent implements OnInit, OnDestroy {
  title: string = '';
  isInfo: boolean = false;
  id: number = 0;
  modelo: ProfesorEntity = {};
  private sub: any;

  constructor(
    private srvProfesor: ProfesorService,
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
      this.srvProfesor
        .getById(this.id)
        .subscribe((result) => (this.modelo = result));
  }
  onSave() {
    if (this.title == 'nuevo') {
      this.srvProfesor
        .insert(this.modelo)
        .subscribe(() => this.router.navigate(['profesores']),(error)=>{
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: JSON.stringify(error.message)
          })

        });
    }
    if (this.title == 'editar') {
      this.srvProfesor
        .update(this.modelo)
        .subscribe(() => this.router.navigate(['profesores']),(error)=>{
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: JSON.stringify(error.message)
          })

        });
    }
  }
  onCancel() {
    this.router.navigate(['profesores']);
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
