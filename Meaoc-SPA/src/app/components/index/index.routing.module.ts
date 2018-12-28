import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from 'src/app/components/index/index/index.component';
import { LoginFormComponent } from 'src/app/components/index/login-form/login-form.component';
import { AboutComponent } from './about/about.component';
import { IndexMenuGuard } from 'src/app/guards/index-menu.guard';
import { PageNotFoundComponent } from '../page-not-found/page-not-found.component';
import { WelcomeComponent } from './welcome/welcome.component';

const indexRouting: Routes = [
  {
    path: 'index',
    component: IndexComponent,
    canActivate: [IndexMenuGuard],
    children: [
      {
        path: '',
        component: IndexComponent,
        children: [
          { path: 'about', component: AboutComponent },
          { path: 'login', component: LoginFormComponent },
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(indexRouting)],
  exports: [RouterModule]
})
export class IndexRoutingModule {}
