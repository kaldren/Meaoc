import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from 'src/app/components/index/index/index.component';
import { LoginFormComponent } from 'src/app/components/index/login-form/login-form.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { AboutComponent } from './about/about.component';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { IndexMenuGuard } from 'src/app/guards/index-menu.guard';

const indexRouting: Routes = [
  {
    path: '',
    component: IndexComponent,
    canActivate: [IndexMenuGuard],
    children: [
      {
        path: '',
        component: IndexComponent,
        children: [
          { path: 'welcome', component: WelcomeComponent },
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
