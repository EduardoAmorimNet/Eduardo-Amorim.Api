import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { CalculoResult } from './CalculoResult';
import { environment } from 'src/environments/environment';
import { CalculoRequest } from './CalculoRequest';
import { Observable, catchError, map, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http: HttpClient) { }


  simularCalculoCDB(request: CalculoRequest){
    return this.http.post<CalculoResult>(environment.BASE_URL + 'CalcularCDB', request);
  }
}
