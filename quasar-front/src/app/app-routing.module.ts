import { AppComponent } from './app.component';
import { HomeComponent } from './core/paginas/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "home"
  },
  {
    path: "home",
    component: HomeComponent
  },
  {
    path: "teste",
    component: AppComponent
  },
  {
    path: 'carrinho',
    loadChildren: () =>

    import('../app/carrinho/carrinho.module').then((m) => m.CarrinhoModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
