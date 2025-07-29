import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ativo, CreateAtivoDto, UpdateAtivoDto } from '../models/ativo.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AtivoService {
  private apiUrl = `${environment.apiUrl}/api/ativos`;

  constructor(private http: HttpClient) { }

  getAtivos(): Observable<Ativo[]> {
    return this.http.get<Ativo[]>(this.apiUrl);
  }

  getAtivo(id: number): Observable<Ativo> {
    return this.http.get<Ativo>(`${this.apiUrl}/${id}`);
  }

  getAtivoByTicker(ticker: string): Observable<Ativo> {
    return this.http.get<Ativo>(`${this.apiUrl}/ticker/${ticker}`);
  }

  createAtivo(ativo: CreateAtivoDto): Observable<Ativo> {
    return this.http.post<Ativo>(this.apiUrl, ativo);
  }

  updateAtivo(id: number, ativo: UpdateAtivoDto): Observable<Ativo> {
    return this.http.put<Ativo>(`${this.apiUrl}/${id}`, ativo);
  }

  deleteAtivo(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  updateCotacao(ticker: string, preco: number): Observable<void> {
    return this.http.patch<void>(`${this.apiUrl}/${ticker}/cotacao`, preco);
  }
}

