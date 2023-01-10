import { AuthGuard } from './shared/guards/auth.guard';
import { HomeComponent } from './core/paginas/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './core/paginas/login/login.component';
import { FinalizarVendaComponent } from './vendas/paginas/finalizar-venda/finalizar-venda.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home',
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "vendas",
    loadChildren: () => import("./vendas/vendas.module").then((m) => m.VendasModule)
  },
  {
    path: "carrinho",
    loadChildren: () => import("./carrinho/carrinho.module").then((m) => m.CarrinhoModule),
    canActivate: [AuthGuard],
  },
  {
    path: 'produtos',
    loadChildren: () =>
      import('./produtos/produtos.module').then((m) => m.ProdutosModule),
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'perfil',
    component: HomeComponent, // TROCAR QUANDO FOR FEITO A PAGINA DO PERFIL
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
