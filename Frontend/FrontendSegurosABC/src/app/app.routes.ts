import { Routes } from '@angular/router';
import { NuevoAseguradoComponent } from './nuevo-asegurado/nuevo-asegurado.component';
import { GestionAseguradoComponent } from './gestion-asegurado/gestion-asegurado.component';
import { AppComponent } from './app.component'; 

export const routes: Routes = [
    { path: 'formulario_asegurados', component: NuevoAseguradoComponent },
    { path: 'gestion_asegurados', component: GestionAseguradoComponent },
    { path: '', component: AppComponent },
  ];  