import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { EtapasService } from '../services/etapas.service';

@Injectable({
  providedIn: 'root'
})
export class EtapasGuard implements CanActivate {

  constructor(
    private etapasService: EtapasService,
    private router: Router
    ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const rota = this.router.url;

    if (rota == "/vendas/endereco") {
      return true;
    }

    if (rota == "/vendas/pagamento") {
      if(this.etapasService.pagamentoConcluido){
        return true;
      }
    }
    this.router.navigate(['/vendas'])
    return false;
  }

}
