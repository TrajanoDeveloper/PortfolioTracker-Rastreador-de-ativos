export interface Ativo {
  id: number;
  ticker: string;
  nome: string;
  descricao?: string;
  tipo: TipoAtivo;
  setor?: string;
  segmento?: string;
  precoAtual?: number;
  dataUltimaAtualizacao?: Date;
  isAtivo: boolean;
}

export interface CreateAtivoDto {
  ticker: string;
  nome: string;
  descricao?: string;
  tipo: TipoAtivo;
  setor?: string;
  segmento?: string;
}

export interface UpdateAtivoDto {
  nome: string;
  descricao?: string;
  tipo: TipoAtivo;
  setor?: string;
  segmento?: string;
  isAtivo: boolean;
}

export enum TipoAtivo {
  Acao = 1,
  FII = 2,
  ETF = 3,
  RendaFixa = 4,
  Criptomoeda = 5,
  Commodity = 6
}

