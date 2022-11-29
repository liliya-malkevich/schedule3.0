import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Faculty } from '../models/schedule.models';
import { Observable } from 'rxjs';
import { HttpService } from './config/http.service';
import DataSource from 'devextreme/data/data_source';


@Injectable({
  providedIn: 'root'
})
export class ScheduleService extends HttpService{
  private apiUrl: string = this.apiAddress + '/schedule';

  constructor(override http: HttpClient) {
    super(http);
  }

  public getFaculty(): DataSource  {
    return new DataSource({
      loadMode: "raw",
      load: () => this.sendRequest(this.apiUrl + '/faculty')
    });
  }

  public getCourse(): DataSource  {
    return new DataSource({
      loadMode: "raw",
      load: () => this.sendRequest(this.apiUrl + '/course')
    });
  }

  public getGroup(idFormaTime: number, IdKurs: number|undefined,IdF: number|undefined): DataSource {
    return new DataSource({
      loadMode: "raw",
      load: () => this.sendRequest(`${this.apiUrl}/gruops?idFormaTime=${idFormaTime}&IdKurs=${IdKurs}&IdF=${IdF}`)
    });
  }
}
