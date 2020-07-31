import { DescricaoCodigoOperacao } from '../../models/ecodigooperacao.enum';
import { ApiService } from '../../services/api-service';
import { Component, OnInit } from '@angular/core';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html'
})
export class HistoryComponent implements OnInit {
  public historico: Historico[];
  public type: string;
  public message: string;

  constructor(private _apiService: ApiService) { }

  async ngOnInit() {
    this.historico = await this._apiService.getHistory().toPromise();
  }

  descricaoOperacao(x: number): string {
    return DescricaoCodigoOperacao.get(x);
  }

  private alert(type: string, message: string = ''): void {
    this.type = type;
    this.message = message;
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
