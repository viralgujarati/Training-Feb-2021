import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HomePageComponent } from './home-page/home-page.component';
// import { StarplusComponent } from './starplus/starplus.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
import { SubscribeComponent } from './subscribe/subscribe.component';
import { LoginComponent } from './login/login.component';
import { ContentDisplayComponent } from './content-display/content-display.component';
import { MovieComponent } from './movie/movie.component';
import { AuthGuard } from './auth.guard';
import { PremiumComponent } from './premium/premium.component';
import { TokenInterceptorService } from './token-interceptor.service';
import { AuthenticationService } from './authentication.service';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { AdminComponent } from './admin/admin.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    RegisterComponent,
    SubscribeComponent,
    LoginComponent,
    ContentDisplayComponent,
    MovieComponent,
    PremiumComponent,
    ConfirmEmailComponent,
    AdminComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [AuthGuard, AuthenticationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    }],
  bootstrap: [AppComponent, AuthGuard]
})
export class AppModule { }
