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
        this.downloadFile(response);
        this.alert('success');
      }, error => {
        this.alert('warning', `Ocorreu um erro inesperado, por favor tente novamente`);
      });
  }

  private downloadFile(response: any) {
    const blob: Blob = new Blob([atob(response.fileStream)], {type: 'text/csv'});

    const fileName: string = response.fileName;
    const objectUrl: string = URL.createObjectURL(blob);
    const a: HTMLAnchorElement = document.createElement('a') as HTMLAnchorElement;

    a.href = objectUrl;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();

    document.body.removeChild(a);
    URL.revokeObjectURL(objectUrl);
  }
}
