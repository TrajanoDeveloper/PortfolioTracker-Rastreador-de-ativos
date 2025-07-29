import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule, MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';

import { AtivoService } from '../../services/ativo.service';
import { Ativo, TipoAtivo, CreateAtivoDto } from '../../models/ativo.model';

@Component({
  selector: 'app-ativos',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatCardModule,
    MatChipsModule
  ],
  templateUrl: './ativos.component.html',
  styleUrls: ['./ativos.component.scss']
})
export class AtivosComponent implements OnInit {
  ativos: Ativo[] = [];
  displayedColumns: string[] = ['ticker', 'nome', 'tipo', 'setor', 'precoAtual', 'variacao', 'percentualCarteira', 'acoes'];
  
  // Dados mockados baseados no layout
  ativosMockados: any[] = [
    { ticker: 'RZTR11', nome: 'RZ Trust Recebíveis Imobiliários', tipo: 'FII', quantidade: '25.098.654.548.855', precoAtual: 94.88, valorInvestido: 'R$ 2.460.626', valorAtual: 'R$ 2.460.626', percentualCarteira: '666.6%', variacao: '+0.37%' },
    { ticker: 'KNSC11', nome: 'Kinea Rendimentos', tipo: 'FII', quantidade: '27.517.998.079.644', precoAtual: 94.88, valorInvestido: 'R$ 2.610.078', valorAtual: 'R$ 2.430.788', percentualCarteira: '658.2%', variacao: '+1.67%' },
    { ticker: 'MGFF11', nome: 'Maxi Renda', tipo: 'FII', quantidade: '54.316.649.775.643', precoAtual: 94.45, valorInvestido: 'R$ 2.662.314', valorAtual: 'R$ 2.494.081', percentualCarteira: '675.6%', variacao: '+1.48%' },
    { ticker: 'VILG11', nome: 'Vila Logística', tipo: 'FII', quantidade: '32.100.000.340.871', precoAtual: 94.36, valorInvestido: 'R$ 3.081.304', valorAtual: 'R$ 3.030.570', percentualCarteira: '821.5%', variacao: '+0.40%' },
    { ticker: 'VSEC11', nome: 'Vinci Shopping Centers', tipo: 'FII', quantidade: '35.348.050.842.291', precoAtual: 94.36, valorInvestido: 'R$ 3.084.203', valorAtual: 'R$ 3.061.781', percentualCarteira: '829.8%', variacao: '+1.20%' }
  ];

  tiposAtivo = [
    { value: TipoAtivo.Acao, label: 'Ação' },
    { value: TipoAtivo.FII, label: 'FII' },
    { value: TipoAtivo.ETF, label: 'ETF' },
    { value: TipoAtivo.RendaFixa, label: 'Renda Fixa' }
  ];

  constructor(
    private ativoService: AtivoService,
    private dialog: MatDialog,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadAtivos();
  }

  loadAtivos() {
    this.ativoService.getAtivos().subscribe({
      next: (ativos) => {
        this.ativos = ativos;
      },
      error: (error) => {
        console.error('Erro ao carregar ativos:', error);
        // Usar dados mockados em caso de erro
        this.ativos = this.ativosMockados as any;
      }
    });
  }

  getTipoLabel(tipo: TipoAtivo): string {
    const tipoObj = this.tiposAtivo.find(t => t.value === tipo);
    return tipoObj ? tipoObj.label : 'Desconhecido';
  }

  getTipoColor(tipo: string): string {
    switch (tipo) {
      case 'FII': return '#e74c3c';
      case 'ETF': return '#3498db';
      case 'Acao': return '#27ae60';
      case 'RendaFixa': return '#9b59b6';
      default: return '#95a5a6';
    }
  }

  editarAtivo(ativo: Ativo) {
    // Implementar modal de edição
    console.log('Editar ativo:', ativo);
  }

  excluirAtivo(ativo: Ativo) {
    if (confirm(`Deseja realmente excluir o ativo ${ativo.ticker}?`)) {
      this.ativoService.deleteAtivo(ativo.id).subscribe({
        next: () => {
          this.loadAtivos();
        },
        error: (error) => {
          console.error('Erro ao excluir ativo:', error);
        }
      });
    }
  }

  adicionarAtivo() {
    // Implementar modal de adição
    console.log('Adicionar novo ativo');
  }
}

