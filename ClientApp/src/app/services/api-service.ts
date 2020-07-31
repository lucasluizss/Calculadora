import { Request } from './../models/request.model';
import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class ApiService {

  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  getHistory(): Observable<Historico[]> {
    return this.http.get<any>(`${this._baseUrl}api/Get`);
  }

  calcular({numero1, numero2, operacao}: Request): Observable<number> {
    return this.http.post<any>(`${this._baseUrl}api/Calcular`, { numero1: +numero1, numero2: +numero2, operacao: +operacao });
  }

  download(): Observable<any> {
    return this.http.get<any>(`${this._baseUrl}api/Download`, { responseType: 'blob' });
  }
}
