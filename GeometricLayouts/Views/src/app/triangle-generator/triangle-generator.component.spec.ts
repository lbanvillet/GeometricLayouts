import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TriangleGeneratorComponent } from './triangle-generator.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { TriangleService } from '../http/triangle.service';
import { of as observableOf, throwError } from 'rxjs';

describe('TriangleGeneratorComponent', () => {
  let component: TriangleGeneratorComponent;
  let fixture: ComponentFixture<TriangleGeneratorComponent>;
  let triangleService: TriangleService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        FormsModule,
        HttpClientModule
      ],
      declarations: [
        TriangleGeneratorComponent
      ],
      providers: [
        Ng4LoadingSpinnerService
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TriangleGeneratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    triangleService = TestBed.get(TriangleService);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('#onShowTriangle', () => {
    it(`should set the triangle when the service call is successful`, () => {
      const serviceResponse = {
        v1: { x: 20, y: 20 },
        v2: { x: 20, y: 10 },
        v3: { x: 30, y: 20 }
      };
      spyOn(triangleService, 'getTriangle').and.returnValue(observableOf(serviceResponse));

      component.onShowTriangle();

      expect(triangleService.getTriangle).toHaveBeenCalled();
      expect(component.triangle).toEqual(serviceResponse);
    });

    it(`should display the right message when the service returns a bad request error`, () => {
      spyOn(triangleService, 'getTriangle').and.returnValue(throwError({ status: 400 }));

      component.onShowTriangle();

      expect(triangleService.getTriangle).toHaveBeenCalled();
      expect(component.errorMessage).toEqual('The requested name is invalid');
    });

    it(`should display a default message when the service returns a different error`, () => {
      spyOn(triangleService, 'getTriangle').and.returnValue(throwError({ status: 500 }));

      component.onShowTriangle();

      expect(triangleService.getTriangle).toHaveBeenCalled();
      expect(component.errorMessage).toEqual('An unexpected error occurred');
    });
  });
});
