import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';

@Component({
  selector: 'app-cotacoes',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatGridListModule
  ],
  templateUrl: './cotacoes.component.html',
  styleUrls: ['./cotacoes.component.scss']
})
export class CotacoesComponent implements OnInit {
  
  // Dados mockados baseados no layout
  cotacoes = [
    { ticker: 'RZTR11', nome: 'RZ Trust Recebíveis Imobiliários', precoAtual: 94.88, variacao: 0.37, variacaoPercentual: 0.39, volume: '25.098.654.548.855', valorTotal: 'R$ 2.460.626' },
    { ticker: 'KNSC11', nome: 'Kinea Rendimentos', precoAtual: 94.88, variacao: 1.67, variacaoPercentual: 1.79, volume: '27.517.998.079.644', valorTotal: 'R$ 2.610.078' },
    { ticker: 'MGFF11', nome: 'Maxi Renda', precoAtual: 94.45, variacao: 1.48, variacaoPercentual: 1.59, volume: '54.316.649.775.643', valorTotal: 'R$ 2.662.314' },
    { ticker: 'VILG11', nome: 'Vila Logística', precoAtual: 94.36, variacao: 0.40, variacaoPercentual: 0.43, volume: '32.100.000.340.871', valorTotal: 'R$ 3.081.304' },
    { ticker: 'VSEC11', nome: 'Vinci Shopping Centers', precoAtual: 94.36, variacao: 1.20, variacaoPercentual: 1.29, volume: '35.348.050.842.291', valorTotal: 'R$ 3.084.203' },
    { ticker: 'BRCO11', nome: 'Banco do Brasil Corporate', precoAtual: 94.77, variacao: -1.50, variacaoPercentual: -1.56, volume: '38.307.806.417.523', valorTotal: 'R$ 3.083.332' },
    { ticker: 'DIVO11', nome: 'Caixa Dividendos', precoAtual: 94.88, variacao: -0.65, variacaoPercentual: -0.68, volume: '20.726.138.879.129', valorTotal: 'R$ 1.830.063' },
    { ticker: 'FMOF11', nome = 'Fundo Imobiliário', precoAtual: 94.45, variacao: -0.28, variacaoPercentual: -0.29, volume: '40.318.790.188.562', valorTotal: 'R$ 1.830.383' },
    { ticker: 'SMAL11', nome: 'SMA11 MG2 Small Corp', precoAtual: 94.79, variacao: 1.61, variacaoPercentual: 1.73, volume: '23.442.426.566.695', valorTotal: 'R$ 1.869.056' },
    { ticker: 'NACO11', nome: 'Nacional Dividendos', precoAtual: 94.159, variacao: 1.67, variacaoPercentual: 1.80, volume: '11.162.138.276.967', valorTotal: 'R$ 1.879.165' },
    { ticker: 'IVVB11', nome: 'iShares S&P 500', precoAtual: 94.234, variacao: 1.67, variacaoPercentual: 1.80, volume: '7.460.775.650.771', valorTotal: 'R$ 1.853.056' },
    { ticker: 'ACWI11', nome: 'iShares MSCI ACWI', precoAtual: 94.188, variacao: -0.32, variacaoPercentual: -0.34, volume: '9.276.000.566.567', valorTotal: 'R$ 1.844.395' },
    { ticker: 'SELC2031', nome: 'Tesouro Selic 2031', precoAtual: 94.987, variacao: -1.36, variacaoPercentual: -1.41, volume: '3.064.199.053.213.385', valorTotal: 'R$ 3.045.571' },
    { ticker: 'IPCA2029', nome: 'Tesouro IPCA+ 2029', precoAtual: 94.986, variacao: -1.39, variacaoPercentual: -1.44, volume: '3.064.459.964.115.017', valorTotal: 'R$ 3.041.446' },
    { ticker: 'IPCA2030', nome: 'Tesouro IPCA+ 2030', precoAtual: 94.991, variacao: -0.82, variacaoPercentual: -0.85, volume: '2.087.775.640.138.687', valorTotal: 'R$ 3.061.959' }
  ];

  constructor() { }

  ngOnInit(): void {
  }

  getVariacaoClass(variacao: number): string {
    return variacao >= 0 ? 'success' : 'danger';
  }
}

