import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexRoutingModule } from 'src/app/modules/index-routing/index.routing.module';
import { IndexComponent } from './index/index.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
      CommonModule,
      IndexRoutingModule,
      FormsModule
    ],
  declarations: [
      IndexComponent,
      LoginFormComponent
  ]
})
export class IndexModule { }
