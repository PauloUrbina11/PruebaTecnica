import { Component, OnInit } from '@angular/core';
import { AseguradosService } from '../src/app/api/api/asegurados.service';
import { SegurosAbc } from '../src/app/api/model/segurosAbc';
import { FormsModule } from '@angular/forms';
import { NgFor } from '@angular/common';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-gestion-asegurado',
  templateUrl: './gestion-asegurado.component.html',
  styleUrls: ['./gestion-asegurado.component.css'],
  standalone: true,
  imports: [FormsModule, NgFor],
})
export class GestionAseguradoComponent implements OnInit {
  asegurados: SegurosAbc[] = [];
  aseguradosFiltrados: SegurosAbc[] = [];
  filtroIdentificacion: string = '';
  filtroSubject: Subject<string> = new Subject<string>();

  constructor(private aseguradosService: AseguradosService) {}

  ngOnInit(): void {
    this.cargarAsegurados();

    this.filtroSubject.pipe(
      debounceTime(1000),
      distinctUntilChanged()
    ).subscribe(value => {
      this.ejecutarFiltro(value);
    });
  }

  cargarAsegurados(): void {
    this.aseguradosService.apiAseguradosListarAseguradosGet().subscribe((response: any) => {
      if (response && response.data) {
        this.asegurados = response.data;
        this.aseguradosFiltrados = response.data;
      }
    });
  }

  onFiltroChange(value: string): void {
    this.filtroSubject.next(value);
  }

  ejecutarFiltro(value: string): void {
    if (!value.trim()) {
      this.aseguradosFiltrados = [...this.asegurados];
      return;
    }
  
    const identificacion = Number(value);
    if (!isNaN(identificacion)) {
      this.aseguradosService.apiAseguradosFiltrarAseguradosIdentificacionGet(identificacion).subscribe(
        (data: SegurosAbc) => {
          this.aseguradosFiltrados = data ? [data] : [];
        },
        (error) => {
          console.error('Error al filtrar asegurados:', error);
          this.aseguradosFiltrados = [];
        }
      );
    } else {
      this.aseguradosFiltrados = [];
    }   
  }

  eliminarAsegurado(identificacion: number | undefined): void {
    if (identificacion !== undefined) {
      if (confirm('¿Estás seguro de eliminar este asegurado?')) {
        this.aseguradosService.apiAseguradosEliminarAseguradosIdentificacionDelete(identificacion).subscribe(
          () => {
            alert('Asegurado eliminado exitosamente');
            this.cargarAsegurados();
          },
          (error) => {
            console.error('Error al eliminar asegurado:', error);
            alert('Hubo un error al eliminar el asegurado. Por favor, inténtelo de nuevo más tarde.');
          }
        );
      }
    } else {
      console.error('Identificación no válida.');
      alert('Error: Identificación no válida.');
    }
  }  

  editarAsegurado(asegurado: SegurosAbc): void {
    if (asegurado.identificacion === undefined || asegurado.identificacion === null) {
      alert('Identificación inválida');
      return;
    }
  
    if (confirm('¿Estás seguro de guardar los cambios?')) {
      this.aseguradosService.apiAseguradosActualizarAseguradoIdentificacionPut(asegurado.identificacion, asegurado)
        .subscribe(
          (response) => {
            alert('Asegurado actualizado exitosamente');
            this.cargarAsegurados();
          },
          (error) => {
            console.error('Error al actualizar asegurado:', error);
            alert('Hubo un error al guardar los cambios. Por favor, inténtelo de nuevo más tarde.');
          }
        );
    }
  }  
}
