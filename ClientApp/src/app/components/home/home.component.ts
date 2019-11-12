import { ApiService } from './../../services/api-service';
import { Component } from '@angular/core';
import { Request } from '../../models/request.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public type: string;
  public message: string;

  public request: Request = new Request();
  public resultado: number;

  constructor(
    private _apiService: ApiService
  ) {}

  private alert(type: string, message: string = '') : void {
    this.type = type;
    this.message = message;
    setTimeout(() => { this.type = this.message = ''; }, 5000);
  }

  public calcular(): void {
    this._apiService.calcular(this.request)
      .subscribe(response => {
        this.resultado = response;
        this.request = new Request();
        this.alert('success');
      }, error => {
        this.alert('warning', `Ocorreu um erro inesperado, por favor tente novamente`);
      });
  }
}
