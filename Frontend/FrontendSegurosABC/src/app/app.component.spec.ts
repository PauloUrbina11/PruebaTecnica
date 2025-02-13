import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { Title } from '@angular/platform-browser';
import { By } from '@angular/platform-browser';

describe('AppComponent', () => {
  let fixture: ComponentFixture<AppComponent>;
  let titleService: Title;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AppComponent],
      providers: [Title]
    });
    
    fixture = TestBed.createComponent(AppComponent);
    titleService = TestBed.inject(Title);
  });

  it('should change the title to "Seguros ABC"', () => {
    spyOn(titleService, 'setTitle'); 
    
    fixture.detectChanges();
    
    expect(titleService.setTitle).toHaveBeenCalledWith('Seguros ABC');
  });
});
