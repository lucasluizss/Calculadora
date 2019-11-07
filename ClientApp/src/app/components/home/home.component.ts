import { ApiService } from './../../services/api-service';
import { Component } from '@angular/core';
import { Request } from '../../models/request.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public request: Request = new Request();
  public resultado: number;

  constructor(
    private _apiService: ApiService
  ) {}

  public calcular(): void {
    this._apiService.calcular(this.request)
      .subscribe(response => {
        this.resultado = response;
      }, error => {
        alert(`Ocorreu um erro inesperado, por favor tente novamente`);
        console.error(error);
      });
  }
}
