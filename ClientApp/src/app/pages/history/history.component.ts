import { DescricaoCodigoOperacao } from '../../models/ecodigooperacao.enum';
import { ApiService } from '../../services/api-service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html'
})
export class HistoryComponent implements OnInit {
  public historico: Historico[];

  constructor(private _apiService: ApiService) { }

  async ngOnInit() {
    this.historico = await this._apiService.getHistory().toPromise();
  }

  descricaoOperacao(x: number): string {
    return DescricaoCodigoOperacao.get(x);
  }

  exportar() {
    this._apiService.download().subscribe(data => {
      this.baixarArquivo(
        data,
        `application/octet-stream`,
        `historico`,
        'csv'
      );
    });
  }

  private baixarArquivo(
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
