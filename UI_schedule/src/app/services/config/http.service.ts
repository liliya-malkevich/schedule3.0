import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { alert, confirm } from 'devextreme/ui/dialog';
import { Observable } from 'rxjs';
import * as gv from './global-variables';

export class HttpService {
  protected apiAddress: string = gv.apiAddress;

  constructor(protected http: HttpClient) {}
  private router = inject(Router);

  protected sendRequest(url: string, method: string = 'GET', data: any = {}): any {
    let httpParams = data;
    //let httpOptions = { withCredentials: true, body: httpParams };
    let result: Observable<Object> = undefined!;

    switch (method) {
      case 'GET':
        result = this.http.get(url, { withCredentials: false });
        break;
      case 'PUT':
        result = this.http.put(url, httpParams);
        break;
      case 'POST':
        result = this.http.post(url, httpParams);
        break;
      case 'DELETE':
        result = this.http.delete(url);
        break;
    }

    if (result != undefined) {
      return result.toPromise().catch((e) => {
        this.showExceptionMessage(e);
        throw e && e.error && e.error.Message;
      });
    }
    else return {};
  }

  protected showExceptionMessage(e: any) {
    if (e) {
      if (e.status === 401) {

        this.router.navigate(['']);
      }
      let message: string = '';
      let excMessage: string = '';
      let additionExcMsg: string = '';
      let responseMessage = e.statusText ? e.statusText: '';
      console.error(e);

      if (e.error) {
        message = e.error.Message ? e.error.Message : '';
        excMessage = e.error.ExceptionMessage ? e.error.ExceptionMessage : '';
        if (e.error.error) {
          additionExcMsg = e.error.error.message ? e.error.error.message : '';
        }
      }
      alert('<p style="color:red;">' + message + ' ' + excMessage + ' ' + additionExcMsg +' (' + responseMessage + ')</p>', 'Ошибка');
    } else {
      alert('<p style="color:red;">' + 'Неизвестная ошибка' + '</p>', 'Ошибка');
    }
  }

  public static showException(excMsg: string): void {
    alert('<p style="color:red;">'+ excMsg + '</p>', 'Ошибка');
  }
}
