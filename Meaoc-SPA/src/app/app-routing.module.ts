import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './components/home/home/home.component';
import { MessagesComponent } from './components/home/messages/messages.component';

const routes: Routes = [
  {
    path: '',
    loadChildren: './components/index/index.module#IndexModule'
  },
  {
    path: '',
    loadChildren: './components/home/home.module#HomeModule'
  }
  // { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  // {
  //   path: 'home/messages',
  //   component: MessagesComponent,
  //   canActivate: [AuthGuard]
  // },
  // { path: '', redirectTo: '/home', pathMatch: 'full' },
  // { path: '**', redirectTo: '/index', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
