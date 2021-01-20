import { AsignaturaService } from './../../../services/asignatura.service';
import { AsignaturaEntity } from './../../../models/asignaturaEntity';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-asignatura-index',
  templateUrl: './asignatura-index.component.html',
  styleUrls: ['./asignatura-index.component.scss'],
})
export class AsignaturaIndexComponent implements OnInit {
  data: AsignaturaEntity[] = [];

  constructor(
    public srvAsignatura: AsignaturaService,
    private router: Router
  ) {}

  loadData() {
    this.data = [];
    this.srvAsignatura.getAll().subscribe(
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
        this.srvAsignatura.delete(id).subscribe(() => this.loadData());
      }
    });
  }
}
