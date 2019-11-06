import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class ApiService {
  
  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  getForecasts(): Observable<any> {
    return this.http.get<any>(`${this._baseUrl}api/Get`);
  }

  calcular(numero1: number, numero2: number, operacao: number): Observable<any> {
    return this.http.post<any>(`${this._baseUrl}api/Calcular`, { numero1, numero2, operacao });
  }
}