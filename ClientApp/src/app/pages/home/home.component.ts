import { ApiService } from '../../services/api-service';
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

  private alert(type: string, message: string = ''): void {
    this.type = type;
    this.message = message;
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

  public download(): void {
    this._apiService.download()
      .subscribe(response => {
        this.downloadFile(response, `text/csv`, `Calculator_history_${new Date()}`, 'csv');
        this.alert('success');
      }, error => {
        this.alert('warning', `Ocorreu um erro inesperado, por favor tente novamente`);
      });
  }

  private downloadFile(
    data: any,
    tipo: string,
    nome: string,
    formato: string
  ) {
    const blob = new Blob([data], { type: tipo });
    const url = window.URL.createObjectURL(blob);
    const anchor = document.createElement('a');
    anchor.download = `${nome}.${formato.toLowerCase()}`;
    anchor.href = url;
    anchor.click();
    window.URL.revokeObjectURL(url);
  }
}
