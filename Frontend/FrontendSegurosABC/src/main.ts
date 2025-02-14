import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core'; 
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';
import { AseguradosService } from './app/src/app/api/api/asegurados.service'; 

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    importProvidersFrom(HttpClientModule),
    AseguradosService
  ]
}).catch(err => console.error(err));