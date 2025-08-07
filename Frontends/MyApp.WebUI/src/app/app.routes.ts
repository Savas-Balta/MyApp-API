import { Routes } from '@angular/router';
import { Layout } from './layout/layout';
import { AuthGuard } from './services/auth-guard';

export const routes: Routes = [{
  path: '',
  component: Layout,
  children: [
    { path: 'contents', loadComponent: () => import('./pages/public-contents/public-contents').then(m => m.PublicContents) },
    { path: 'my-contents', loadComponent: () => import('./pages/my-contents/my-contents').then(m => m.MyContents) },
    { path: 'login', loadComponent: () => import('./pages/auth/login/login').then(m => m.Login) },
    { path: 'register', loadComponent: () => import('./pages/auth/register/register').then(m => m.Register) },
    { path: 'contents/add', loadComponent: () => import('./pages/content-form/content-form').then(m => m.ContentForm), canActivate: [AuthGuard] },
    { path: 'contents/edit/:id', loadComponent: () => import('./pages/content-form/content-form').then(m => m.ContentForm), canActivate: [AuthGuard] },
    { path: 'contents/:id', loadComponent: () => import('./pages/content-detail/content-detail').then(m => m.ContentDetail) }
  ]
}];
