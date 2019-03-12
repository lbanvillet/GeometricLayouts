import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NameCalculatorComponent } from './name-calculator.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { Vertex } from '../model/vertex';
import { TriangleService } from '../http/triangle.service';
import { of as observableOf, throwError } from 'rxjs';

describe('NameCalculatorComponent', () => {
  let component: NameCalculatorComponent;
  let fixture: ComponentFixture<NameCalculatorComponent>;
  let triangleService: TriangleService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        FormsModule,
        HttpClientModule
      ],
      declarations: [
        NameCalculatorComponent
      ],
      providers: [
        Ng4LoadingSpinnerService
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NameCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    triangleService = TestBed.get(TriangleService);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(component.triangle).toEqual({
      v1: new Vertex(),
      v2: new Vertex(),
      v3: new Vertex()
    });
  });

  describe('#onShowName', () => {
    it(`should set the triangle name when the service call is successful`, () => {
      const serviceResponse = { name: 'B5' };
      spyOn(triangleService, 'getName').and.returnValue(observableOf(serviceResponse));

      component.onShowName();

      expect(triangleService.getName).toHaveBeenCalled();
      expect(component.triangleName).toEqual(serviceResponse.name);
    });

    it(`should display the right message when the service returns a bad request error`, () => {
      spyOn(triangleService, 'getName').and.returnValue(throwError({ status: 400 }));

      component.onShowName();

      expect(triangleService.getName).toHaveBeenCalled();
      expect(component.errorMessage).toEqual('The format of the parameters in incorrect');
    });

    it(`should display the right message when the service returns a not found error`, () => {
      spyOn(triangleService, 'getName').and.returnValue(throwError({ status: 404 }));

      component.onShowName();

      expect(triangleService.getName).toHaveBeenCalled();
      expect(component.errorMessage).toEqual('The entered coordinates do not belong to any triangle');
    });

    it(`should display a default message when the service returns a different error`, () => {
      spyOn(triangleService, 'getName').and.returnValue(throwError({ status: 500 }));

      component.onShowName();

      expect(triangleService.getName).toHaveBeenCalled();
      expect(component.errorMessage).toEqual('An unexpected error occurred');
    });
  });
});
