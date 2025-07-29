export interface DashboardData {
  totalAplicado: number;
  totalAtual: number;
  rentabilidade: number;
  rentabilidadePercentual: number;
  quantidadeAtivos: number;
  precoMedio: number;
  posicoes: PosicaoResumo[];
  rendimentosMensais: RendimentoMensal[];
  reservaEmergencia: ReservaEmergencia;
  objetivosAtivos: ObjetivoAtivo[];
}

export interface PosicaoResumo {
  ticker: string;
  nome: string;
  quantidade: number;
  precoMedio: number;
  valorInvestido: number;
  valorAtual: number;
  percentualCarteira: number;
  variacao: number;
  variacaoPercentual: number;
}

export interface RendimentoMensal {
  ano: number;
  mes: number;
  mesNome: string;
  valor: number;
}

export interface ReservaEmergencia {
  valorAtual: number;
  valorObjetivo: number;
  percentualAlcancado: number;
}

export interface ObjetivoAtivo {
  ticker: string;
  percentualObjetivo: number;
  percentualAtual: number;
  diferencaPercentual: number;
}

