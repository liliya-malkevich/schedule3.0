import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Faculty } from '../models/faculty.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FacultyService{
  baseUrl = 'https://localhost:7119/schedule/faculty'

  constructor(private http: HttpClient) { }

  GetListSchedule(): Observable<Faculty[]>{
return this.http.get<Faculty[]>(this.baseUrl);
  }
}
