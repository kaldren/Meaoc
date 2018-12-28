import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './components/home/home/home.component';
import { MessagesComponent } from './components/home/messages/messages.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { WelcomeComponent } from './components/index/welcome/welcome.component';
import { IndexComponent } from './components/index/index/index.component';
import { IndexMenuGuard } from './guards/index-menu.guard';
import { LoginFormComponent } from './components/index/login-form/login-form.component';

const routes: Routes = [
  {
    path: 'index',
    // loadChildren: './components/index/index.module#IndexModule'
    component: IndexComponent,
  },
  {
    path: 'home',
    // loadChildren: './components/home/home.module#HomeModule'
    component: HomeComponent,
    canActivate: [AuthGuard]
  },
  { path: 'index/welcome', component: WelcomeComponent },
  { path: '', redirectTo: 'index/welcome', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
