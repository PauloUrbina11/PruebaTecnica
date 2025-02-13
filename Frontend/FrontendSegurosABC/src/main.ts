import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { HttpClientModule } from '@angular/common/http'; // Importa HttpClientModule
import { importProvidersFrom } from '@angular/core'; // Importa importProvidersFrom
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';
import { AseguradosService } from './app/src/app/api/api/asegurados.service'; // Importa AseguradosService

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    importProvidersFrom(HttpClientModule),
    AseguradosService
  ]
}).catch(err => console.error(err));