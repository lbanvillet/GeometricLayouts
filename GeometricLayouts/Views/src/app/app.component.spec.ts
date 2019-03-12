import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { TriangleGeneratorComponent } from './triangle-generator/triangle-generator.component';
import { NameCalculatorComponent } from './name-calculator/name-calculator.component';
import { Ng4LoadingSpinnerComponent, Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

describe('AppComponent', () => {
  let fixture: ComponentFixture<AppComponent>;
  let app: AppComponent;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        FormsModule,
        HttpClientModule
      ],
      declarations: [
        AppComponent,
        TriangleGeneratorComponent,
        NameCalculatorComponent,
        Ng4LoadingSpinnerComponent
      ],
      providers: [
        Ng4LoadingSpinnerService
      ]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    app = fixture.debugElement.componentInstance;
    fixture.detectChanges();
  });

  it('should create the app', () => {
    expect(app).toBeTruthy();
    expect(app.isNameCalculatorVisible).toBeFalsy();
  });

  it('should render the triangle-generator component by default', () => {
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('app-triangle-generator').hidden).toBeFalsy();
  });

  describe('#onShowNameCalculator', () => {
    it(`should set the switcher boolean to true`, () => {
      app.onShowNameCalculator();
      expect(app.isNameCalculatorVisible).toBeTruthy();
    });
  });

  describe('#onShowTriangleGenerator', () => {
    it(`should set the switcher boolean to false`, () => {
      app.onShowTriangleGenerator();
      expect(app.isNameCalculatorVisible).toBeFalsy();
    });
  });
});
