import { ProfesorService } from './../../../services/profesor.service';
import { ProfesorEntity } from './../../../models/profesorEntity';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-profesor-index',
  templateUrl: './profesor-index.component.html',
  styleUrls: ['./profesor-index.component.scss'],
})
export class ProfesorIndexComponent implements OnInit {
  data: ProfesorEntity[] = [];
  constructor(public srvProfesor: ProfesorService,private router: Router) {}

  loadData() {
    this.data = [];
    this.srvProfesor.getAll().subscribe((response) => (this.data = response),(error)=>{
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: JSON.stringify(error.message)
      })

    });
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
        this.srvProfesor.delete(id).subscribe(() => this.loadData());
      }
    });
  }
}
