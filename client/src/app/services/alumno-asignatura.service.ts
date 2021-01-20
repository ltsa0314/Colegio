import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AlumnoAsignaturaEntity } from '../models/alumnoAsignaturaEntity';

@Injectable({
  providedIn: 'root'
})
export class AlumnoAsignaturaService {

  constructor(public http: HttpClient) {}

  getAll(alumnoId?:number): Observable<AlumnoAsignaturaEntity[]> {
    return this.http.get<AlumnoAsignaturaEntity[]>(`${environment.apiUrl}/alumnoasignaturas/${alumnoId}`);
  }
  getById(id: number): Observable<AlumnoAsignaturaEntity> {
    return this.http.get<AlumnoAsignaturaEntity>(
      `${environment.apiUrl}/alumnoasignaturas/${id}`
    );
  }
  insert(model: AlumnoAsignaturaEntity): Observable<AlumnoAsignaturaEntity> {
    console.log(model);
    return this.http
      .post(`${environment.apiUrl}/alumnoasignaturas`, model);
  }
  update(model: AlumnoAsignaturaEntity):Observable<any> {
    return this.http.put(`${environment.apiUrl}/alumnoasignaturas`, model);
  }
  delete(id: number) {
    return this.http
      .delete(`${environment.apiUrl}/alumnoasignaturas/${id}`)
      .subscribe();
  }
}
