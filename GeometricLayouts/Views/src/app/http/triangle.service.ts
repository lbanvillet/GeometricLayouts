import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Triangle } from '../model/triangle';
import { GetTriangleNameResponse } from '../model/get-triangle-name-response';

@Injectable({
  providedIn: 'root'
})
export class TriangleService {
  static URL = '/api/triangles';

  constructor(private http: HttpClient) {}

  getTriangle(name: string): Observable<Triangle> {
    return this.http.get<Triangle>(TriangleService.URL + '/' + name);
  }

  getName(triangle: Triangle): Observable<GetTriangleNameResponse> {
    return this.http.post<GetTriangleNameResponse>(TriangleService.URL + '/name', triangle);
  }
}
