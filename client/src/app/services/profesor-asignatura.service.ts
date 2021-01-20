import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProfesorAsignaturaEntity } from '../models/profesorAsignaturaEntity';

@Injectable({
  providedIn: 'root'
})
export class ProfesorAsignaturaService {

  constructor(public http: HttpClient) {}

  getAll(): Observable<ProfesorAsignaturaEntity[]> {
    return this.http.get<ProfesorAsignaturaEntity[]>(`${environment.apiUrl}/profesorasignaturas`);
  }
  getById(id: number): Observable<ProfesorAsignaturaEntity> {
    return this.http.get<ProfesorAsignaturaEntity>(
      `${environment.apiUrl}/profesorasignaturas/${id}`
    );
  }
  insert(model: ProfesorAsignaturaEntity) {
    return this.http
      .post(`${environment.apiUrl}/profesorasignaturas`, model)
      .subscribe();
  }
  update(model: ProfesorAsignaturaEntity) {
    return this.http.put(`${environment.apiUrl}/profesorasignaturas`, model).subscribe();
  }
  delete(id: number) {
    return this.http
      .delete(`${environment.apiUrl}/profesorasignaturas/${id}`)
      .subscribe();
  }
}
