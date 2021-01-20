import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AsignaturaEntity } from '../models/asignaturaEntity';

@Injectable({
  providedIn: 'root'
})
export class AsignaturaService {

  constructor(public http: HttpClient) {}

  getAll(): Observable<AsignaturaEntity[]> {
    return this.http.get<AsignaturaEntity[]>(`${environment.apiUrl}/asignaturas`);
  }
  getById(id: number): Observable<AsignaturaEntity> {
    return this.http.get<AsignaturaEntity>(
      `${environment.apiUrl}/asignaturas/${id}`
    );
  }

  insert(model: AsignaturaEntity): Observable<AsignaturaEntity> {
    return this.http
      .post<AsignaturaEntity>(`${environment.apiUrl}/asignaturas`, model);
  }

  update(model: AsignaturaEntity): Observable<any> {
    return this.http.put(`${environment.apiUrl}/asignaturas`, model);
  }

  delete(id : number):Observable<any> {
    return this.http
      .delete(`${environment.apiUrl}/asignaturas/${id}`);
  }

}
