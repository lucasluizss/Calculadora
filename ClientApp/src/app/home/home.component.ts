import { ApiService } from './../services/api-service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public numero1: number;
  public numero2: number;

  public operacao: number;
  public resultado: number;

  constructor(
    private _apiService: ApiService
  ) {}

  public calcular(): void {
    this._apiService.calcular(
      Number(this.numero1), 
      Number(this.numero2), 
      Number(this.operacao)
    )
      .subscribe(response => {
        this.resultado = response;
      }, error => {
        alert(`Ocorreu um erro inesperado, por favor tente novamente`);
        console.error(error);
      });
  }
}
