import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-operacoes',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatChipsModule
  ],
  templateUrl: './operacoes.component.html',
  styleUrls: ['./operacoes.component.scss']
})
export class OperacoesComponent implements OnInit {
  displayedColumns: string[] = ['data', 'ativo', 'tipo', 'quantidade', 'preco', 'valorTotal', 'observacoes'];
  
  // Dados mockados baseados no layout
  operacoes = [
    { data: '15/06/2025', ativo: 'RZTR11', nome: 'RZ Trust Recebíveis Imobiliários', tipo: 'COMPRA', quantidade: '53.700.000.533.786', preco: 'R$ 94.19', valorTotal: 'R$ 2.519.50', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'KNSC11', nome: 'Kinea Rendimentos', tipo: 'COMPRA', quantidade: '28.011.540.613.137', preco: 'R$ 89.75', valorTotal: 'R$ 2.519.50', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'MGFF11', nome: 'Maxi Renda', tipo: 'COMPRA', quantidade: '51.614.632.636.264', preco: 'R$ 94.45', valorTotal: 'R$ 2.519.50', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'VILG11', nome: 'Vila Logística', tipo: 'COMPRA', quantidade: '30.443.976.544.824', preco: 'R$ 95.49', valorTotal: 'R$ 2.519.50', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'VSEC11', nome: 'Vinci Shopping Centers', tipo: 'COMPRA', quantidade: '32.349.638.803.337', preco: 'R$ 93.49', valorTotal: 'R$ 2.519.50', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'BRCO11', nome: 'Banco do Brasil Corporate', tipo: 'COMPRA', quantidade: '38.307.806.417.523', preco: 'R$ 76.20', valorTotal: 'R$ 2.519.50', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'DIVO11', nome: 'Caixa Dividendos', tipo: 'COMPRA', quantidade: '19.598.640.479.742', preco: 'R$ 89.30', valorTotal: 'R$ 1.750.00', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'FMOF11', nome: 'Fundo Imobiliário', tipo: 'COMPRA', quantidade: '38.318.790.188.562', preco: 'R$ 45.67', valorTotal: 'R$ 1.750.00', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'SMAL11', nome: 'SMA11 MG2 Small Corp', tipo: 'COMPRA', quantidade: '22.179.976.516.738', preco: 'R$ 78.90', valorTotal: 'R$ 1.750.00', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'NACO11', nome: 'Nacional Dividendos', tipo: 'COMPRA', quantidade: '11.162.138.276.967', preco: 'R$ 156.78', valorTotal: 'R$ 1.750.00', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'IVVB11', nome: 'iShares S&P 500', tipo: 'COMPRA', quantidade: '7.460.775.650.771', preco: 'R$ 234.57', valorTotal: 'R$ 1.750.00', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'ACWI11', nome = 'iShares MSCI ACWI', tipo: 'COMPRA', quantidade: '9.276.000.566.567', preco: 'R$ 188.64', valorTotal: 'R$ 1.750.00', observacoes: 'Investimento inicial' },
    { data: '15/06/2025', ativo: 'SELC2031', nome: 'Tesouro Selic 2031', tipo: 'COMPRA', quantidade: '2.9155', preco: 'R$ 1000.00', valorTotal: 'R$ 2.915.50', observacoes: 'Aporte mensal 06/2025' },
    { data: '15/06/2025', ativo: 'IPCA2029', nome: 'Tesouro IPCA+ 2029', tipo: 'COMPRA', quantidade: '2.9155', preco: 'R$ 1000.00', valorTotal: 'R$ 133.50', observacoes: 'Aporte mensal 06/2025' },
    { data: '15/06/2025', ativo: 'MGFF11', nome: 'Maxi Renda', tipo: 'COMPRA', quantidade: '2.001.900.510.041.231', preco: 'R$ 94.50', valorTotal: 'R$ 133.50', observacoes: 'Aporte mensal 06/2025' },
    { data: '15/06/2025', ativo: 'VILG11', nome: 'Vila Logística', tipo: 'COMPRA', quantidade: '1.728.139.359.95.962', preco: 'R$ 96.14', valorTotal: 'R$ 166.00', observacoes: 'Aporte mensal 06/2025' },
    { data: '15/06/2025', ativo: 'VSEC11', nome: 'Vinci Shopping Centers', tipo: 'COMPRA', quantidade: '1.929.132.072.064.008', preco: 'R$ 85.95', valorTotal: 'R$ 166.00', observacoes: 'Aporte mensal 06/2025' }
  ];

  constructor() { }

  ngOnInit(): void {
  }

  getTipoColor(tipo: string): string {
    switch (tipo) {
      case 'COMPRA': return '#27ae60';
      case 'VENDA': return '#e74c3c';
      case 'DIVIDENDO': return '#3498db';
      default: return '#95a5a6';
    }
  }

  novaOperacao() {
    console.log('Nova operação');
  }
}

