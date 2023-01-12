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
    path: "carrinho",
    loadChildren: () => import("./carrinho/carrinho.module").then((m) => m.CarrinhoModule),
    canActivate: [AuthGuard],
  },
  {
    path: "usuario",
    loadChildren: () => import("./usuario/usuario.module").then((m) => m.UsuarioModule)
  },
  {
    path: 'produtos',
    loadChildren: () => import('./produtos/produtos.module').then((m) => m.ProdutosModule),
  },
  {
    path: "vendas",
    component: FinalizarVendaComponent,
    loadChildren: () => import("./vendas/vendas.module").then((m) => m.VendasModule)
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
