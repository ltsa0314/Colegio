import { ReporteCalificacionesEntity } from './../models/reporteCalificacionesEntity';
import { environment } from './../../environments/environment.prod';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AlumnoEntity } from '../models/alumnoEntity';

@Injectable({
  providedIn: 'root',
})
export class AlumnoService {
  constructor(public http: HttpClient) {}

  getAll(): Observable<AlumnoEntity[]> {
    return this.http.get<AlumnoEntity[]>(`${environment.apiUrl}/alumnos`);
  }
  getReport():Observable<ReporteCalificacionesEntity[]>{
    return this.http.get<ReporteCalificacionesEntity[]>(`${environment.apiUrl}/alumnos/report`);
  }
  getById(id: number): Observable<AlumnoEntity> {
    return this.http.get<AlumnoEntity>(`${environment.apiUrl}/alumnos/${id}`);
  }
  insert(model: AlumnoEntity): Observable<AlumnoEntity> {
    return this.http.post<AlumnoEntity>(`${environment.apiUrl}/alumnos`, model);
  }
  update(model: AlumnoEntity): Observable<any> {
    return this.http.put(`${environment.apiUrl}/alumnos`, model);
  }
  delete(id: number): Observable<any> {
    return this.http.delete(`${environment.apiUrl}/alumnos/${id}`);
  }
}
