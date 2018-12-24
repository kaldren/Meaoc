import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from 'src/app/components/index/index/index.component';
import { LoginFormComponent } from 'src/app/components/index/login-form/login-form.component';

const indexRouting: Routes = [
  {
    path: 'index',
    component: IndexComponent,
    children: [
      {
        path: '',
        children: [{ path: 'login', component: LoginFormComponent }]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(indexRouting)],
  exports: [RouterModule]
})
export class IndexRoutingModule {}
