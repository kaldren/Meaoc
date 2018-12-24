import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './components/home/home/home.component';
import { MessagesComponent } from './components/home/messages/messages.component';

const routes: Routes = [
  { path: 'login', component: LoginFormComponent },
  { path: 'logout', component: LoginFormComponent },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'home/messages', component: MessagesComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
