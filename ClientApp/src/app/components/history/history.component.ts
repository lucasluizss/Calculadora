import { DescricaoCodigoOperacao } from './../../models/ecodigooperacao.enum';
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
}
