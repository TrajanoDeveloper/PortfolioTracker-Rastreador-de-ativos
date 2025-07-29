import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Chart, ChartConfiguration, ChartType, registerables } from 'chart.js';

Chart.register(...registerables);

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatGridListModule,
    MatSelectModule,
    MatFormFieldModule
  ],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  @ViewChild('reservaChart', { static: true }) reservaChart!: ElementRef;
  @ViewChild('objetivoChart', { static: true }) objetivoChart!: ElementRef;
  @ViewChild('realizadaChart', { static: true }) realizadaChart!: ElementRef;
  @ViewChild('comparativoChart', { static: true }) comparativoChart!: ElementRef;
  @ViewChild('rendaPassivaChart', { static: true }) rendaPassivaChart!: ElementRef;

  // Dados mockados baseados nos layouts
  dashboardData = {
    totalAplicado: 37004.21,
    totalAtual: 36926.37,
    rentabilidade: -77.84,
    rentabilidadePercentual: 0.21,
    quantidadeAtivos: 15,
    precoMedio: 2461.79
  };

  anoSelecionado = 2025;
  anos = [2023, 2024, 2025];

  ngOnInit() {
    this.createCharts();
  }

  private createCharts() {
    this.createReservaEmergenciaChart();
    this.createObjetivoCarteiraChart();
    this.createRealizadaCarteiraChart();
    this.createComparativoChart();
    this.createRendaPassivaChart();
  }

  private createReservaEmergenciaChart() {
    const ctx = this.reservaChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'doughnut',
      data: {
        datasets: [{
          data: [60, 40],
          backgroundColor: ['#3498db', '#2c3e50'],
          borderWidth: 0
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: { display: false }
        },
        cutout: '70%'
      }
    });
  }

  private createObjetivoCarteiraChart() {
    const ctx = this.objetivoChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'doughnut',
      data: {
        datasets: [{
          data: [75, 25],
          backgroundColor: ['#9b59b6', '#2c3e50'],
          borderWidth: 0
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: { display: false }
        },
        cutout: '70%'
      }
    });
  }

  private createRealizadaCarteiraChart() {
    const ctx = this.realizadaChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'doughnut',
      data: {
        datasets: [{
          data: [68, 32],
          backgroundColor: ['#9b59b6', '#2c3e50'],
          borderWidth: 0
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: { display: false }
        },
        cutout: '70%'
      }
    });
  }

  private createComparativoChart() {
    const ctx = this.comparativoChart.nativeElement.getContext('2d');
    const tickers = ['RZTR11', 'KNSC11', 'MGFF11', 'VILG11', 'VSEC11', 'BRCO11', 'DIVO11', 'FMOF11', 'SMAL11', 'NACO11', 'IVVB11', 'ACWI11', 'SELC2031', 'IPCA2029', 'IPCA2030'];
    
    new Chart(ctx, {
      type: 'bar',
      data: {
        labels: tickers,
        datasets: [
          {
            label: '% Real',
            data: [8.2, 7.1, 6.8, 5.9, 5.3, 4.7, 4.2, 3.8, 3.4, 2.9, 2.5, 2.1, 1.8, 1.5, 1.2],
            backgroundColor: '#e74c3c'
          },
          {
            label: '% Objetivo',
            data: [10, 8, 7, 6, 5.5, 5, 4.5, 4, 3.5, 3, 2.8, 2.5, 2, 1.8, 1.5],
            backgroundColor: '#3498db'
          }
        ]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            position: 'bottom',
            labels: { color: '#ffffff' }
          }
        },
        scales: {
          x: {
            ticks: { color: '#ffffff' },
            grid: { color: '#3a3f51' }
          },
          y: {
            ticks: { color: '#ffffff' },
            grid: { color: '#3a3f51' }
          }
        }
      }
    });
  }

  private createRendaPassivaChart() {
    const ctx = this.rendaPassivaChart.nativeElement.getContext('2d');
    new Chart(ctx, {
      type: 'line',
      data: {
        labels: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        datasets: [
          {
            label: 'Ano Seleção',
            data: [150, 180, 220, 190, 250, 280, 320, 290, 350, 380, 420, 450],
            borderColor: '#e74c3c',
            backgroundColor: 'rgba(231, 76, 60, 0.1)',
            tension: 0.4
          },
          {
            label: 'Ano Anterior',
            data: [120, 140, 160, 150, 180, 200, 230, 210, 260, 280, 300, 320],
            borderColor: '#95a5a6',
            backgroundColor: 'rgba(149, 165, 166, 0.1)',
            tension: 0.4
          }
        ]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          legend: {
            position: 'bottom',
            labels: { color: '#ffffff' }
          }
        },
        scales: {
          x: {
            ticks: { color: '#ffffff' },
            grid: { color: '#3a3f51' }
          },
          y: {
            ticks: { color: '#ffffff' },
            grid: { color: '#3a3f51' }
          }
        }
      }
    });
  }

  onAnoChange(ano: number) {
    this.anoSelecionado = ano;
    // Aqui você atualizaria os dados do gráfico baseado no ano selecionado
  }
}

