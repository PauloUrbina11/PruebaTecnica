import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionAseguradoComponent } from './gestion-asegurado.component';

describe('GestionAseguradoComponent', () => {
  let component: GestionAseguradoComponent;
  let fixture: ComponentFixture<GestionAseguradoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GestionAseguradoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GestionAseguradoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
