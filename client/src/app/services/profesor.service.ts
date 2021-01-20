import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProfesorEntity } from '../models/profesorEntity';

@Injectable({
  providedIn: 'root',
})
export class ProfesorService {
  constructor(public http: HttpClient) {}

  getAll(): Observable<ProfesorEntity[]> {
    return this.http.get<ProfesorEntity[]>(`${environment.apiUrl}/profesores`);
  }
  getById(id: number): Observable<ProfesorEntity> {
    return this.http.get<ProfesorEntity>(
      `${environment.apiUrl}/profesores/${id}`
    );
  }
  insert(model: ProfesorEntity):Observable<ProfesorEntity> {
    return this.http
      .post<ProfesorEntity>(`${environment.apiUrl}/profesores`, model);

  }

  update(model: ProfesorEntity):Observable<ProfesorEntity> {
    return this.http.put<ProfesorEntity>(`${environment.apiUrl}/profesores`, model);
  }
  delete(id: number):Observable<ProfesorEntity> {
    return this.http
      .delete<ProfesorEntity>(`${environment.apiUrl}/profesores/${id}`);

  }
}
