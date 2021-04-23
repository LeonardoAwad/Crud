import { Injectable, Inject } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Produto } from "../models/Produto";

@Injectable({
  providedIn: "root"
})
export class ProdutoService {
  private baseURL: string;



  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public ListaProduto(): Observable<Produto[]> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {

    };
    return this.http.post<Produto[]>(this.baseURL + "api/produto/ListaProduto", { headers });
    //return this.http.post<Usuario>(this.baseURL + "api/usuario/VerificarUsuario", usuario, { headers });
  }


  public InsereProduto(produto: Produto): Observable<null> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      produto: produto
    };
    return this.http.post<null>(this.baseURL + "api/produto/InsereProduto", body, { headers });
    //return this.http.post<Usuario>(this.baseURL + "api/usuario/VerificarUsuario", usuario, { headers });
  }

  public AlteraProduto(produto: Produto): Observable<null> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      produto: produto
    };
    return this.http.post<null>(this.baseURL + "api/produto/AlteraProduto", body, { headers });
    //return this.http.post<Usuario>(this.baseURL + "api/usuario/VerificarUsuario", usuario, { headers });
  }

  public ExcluirProduto(produto: Produto): Observable<null> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      produto: produto
    };
    return this.http.post<null>(this.baseURL + "api/produto/ExcluirProduto", body, { headers });
    //return this.http.post<Usuario>(this.baseURL + "api/usuario/VerificarUsuario", usuario, { headers });
  }

  

  
}
