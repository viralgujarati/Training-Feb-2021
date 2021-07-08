import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
// import { StarplusComponent } from './starplus/starplus.component';
import { SubscribeComponent } from './subscribe/subscribe.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ContentDisplayComponent } from './content-display/content-display.component';
import { MovieComponent } from './movie/movie.component';
import { AuthGuard } from './auth.guard';
import { PremiumComponent } from './premium/premium.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { AdminComponent } from './admin/admin.component';



const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'home', component: HomePageComponent },
  {
    path: 'subscribe', component: SubscribeComponent,
    canActivate: [AuthGuard]
  },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'content/:id', component: ContentDisplayComponent },
  { path: 'movie', component: MovieComponent },
  { path: 'premium', component: PremiumComponent },
  { path: 'TV/:subCategoryId', loadChildren: () => import('./tv/tv.module').then(m => m.TVModule) },
  { path: 'Sports/:subCategoryId', loadChildren: () => import('./sports/sports.module').then(m => m.SportsModule) },
  { path: 'News', loadChildren: () => import('./news/news.module').then(m => m.NewsModule) },
  { path: 'confirmemail', component: ConfirmEmailComponent },
  { path: 'admin', component: AdminComponent }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
