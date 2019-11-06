import { ApiService } from './../services/api-service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public historico: Historico[];

  constructor(private _apiService: ApiService) { }

  async ngOnInit() {
    this.historico = await this._apiService.getForecasts().toPromise();
  }
}

interface Historico {
  date: string;
  numero1: number;
  numero2: number;
  operacao: number;
  resultado: number;
}
