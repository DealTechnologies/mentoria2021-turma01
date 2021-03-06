import { MeuCarrinhoComponent } from './Components/meu-carrinho/meu-carrinho.component';
import { CardComponent } from './Template/home/card/card.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './Template/home/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { FooterComponent } from './Template/home/footer/footer.component';
import { NavComponent } from './Template/home/nav/nav.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatCardModule } from '@angular/material/card';
import { CadastrarUsuarioComponent } from './Components/cadastrar-usuario/cadastrar-usuario.component';
import { CadastrarProdutoComponent } from './Components/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutoComponent } from './Components/listar-produto/listar-produto.component';
import { LoginService } from './Services/login/login.service';
import { AuthGuardGuard } from './guard/auth-guard.guard';
import { AtualizarUsuarioComponent } from './Components/atualizarUsuario/atualizar-usuario/atualizar-usuario.component';
import { MeusPedidosComponent } from './Components/meus-pedidos/meus-pedidos.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    NavComponent,
    LoginComponent,
    CardComponent,
    CadastrarUsuarioComponent,
    CadastrarProdutoComponent,
    ListarProdutoComponent,
    AtualizarUsuarioComponent,
    MeusPedidosComponent,
    MeuCarrinhoComponent

  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    MatSidenavModule,
    MatListModule,
    MatDialogModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    MatCardModule,
    MatTableModule,

  ],
  providers: [
    LoginService,
    AuthGuardGuard
  ]
  ,
  bootstrap: [AppComponent]
})
export class AppModule { }
