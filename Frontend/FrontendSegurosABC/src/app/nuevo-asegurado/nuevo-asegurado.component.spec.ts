import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NuevoAseguradoComponent } from './nuevo-asegurado.component';

describe('NuevoAseguradoComponent', () => {
  let component: NuevoAseguradoComponent;
  let fixture: ComponentFixture<NuevoAseguradoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NuevoAseguradoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NuevoAseguradoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
