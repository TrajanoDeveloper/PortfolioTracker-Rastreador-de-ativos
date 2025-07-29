import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { 
    path: 'dashboard', 
    loadComponent: () => import('./components/dashboard/dashboard.component').then(m => m.DashboardComponent)
  },
  { 
    path: 'ativos', 
    loadComponent: () => import('./components/ativos/ativos.component').then(m => m.AtivosComponent)
  },
  { 
    path: 'operacoes', 
    loadComponent: () => import('./components/operacoes/operacoes.component').then(m => m.OperacoesComponent)
  },
  { 
    path: 'cotacoes', 
    loadComponent: () => import('./components/cotacoes/cotacoes.component').then(m => m.CotacoesComponent)
  },
  { path: '**', redirectTo: '/dashboard' }
];

