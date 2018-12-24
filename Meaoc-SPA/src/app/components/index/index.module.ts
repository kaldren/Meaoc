import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { IndexRoutingModule } from './index.routing.module';
import { WelcomeComponent } from './welcome/welcome.component';
import { AboutComponent } from './about/about.component';

@NgModule({
  imports: [
      CommonModule,
      FormsModule,
      IndexRoutingModule
    ],
  declarations: [
      WelcomeComponent,
      IndexComponent,
      LoginFormComponent,
      AboutComponent
  ]
})
export class IndexModule { }
