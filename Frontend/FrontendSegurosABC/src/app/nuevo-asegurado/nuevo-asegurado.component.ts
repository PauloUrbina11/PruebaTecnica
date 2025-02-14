import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AseguradosService } from '../src/app/api/api/asegurados.service';
import { SegurosAbc } from '../src/app/api/model/segurosAbc';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nuevo-asegurado',
  templateUrl: './nuevo-asegurado.component.html',
  styleUrls: ['./nuevo-asegurado.component.css'],
  standalone: true,
  imports: [FormsModule, NgIf]
})
export class NuevoAseguradoComponent {
  asegurado: SegurosAbc = {
    identificacion: 0,
    primerNombre: '',
    segundoNombre: '',
    primerApellido: '',
    segundoApellido: '',
    telefono: '',
    correoElectronico: '',
    fechaNacimiento: '',
    valorEstimado: 0,
    observaciones: ''
  };

  mostrarFormulario: boolean = true;

  constructor(private aseguradosService: AseguradosService, private router: Router) { }

  mostrarForm(): void {
    this.mostrarFormulario = true;
  }

  onSubmit() {
    this.aseguradosService.apiAseguradosCrearAseguradoPost(this.asegurado).subscribe(
      (response) => {
        alert('Asegurado registrado exitosamente');
        this.mostrarFormulario = false;
        this.router.navigate(['/']);
      },
      (error) => {
        if (error.error && error.error.message) {
          alert(`Error: ${error.error.message}`);
        } else {
          alert('Hubo un error al registrar el asegurado. Por favor, inténtelo de nuevo más tarde.');
        }
      }
    );
  }
}