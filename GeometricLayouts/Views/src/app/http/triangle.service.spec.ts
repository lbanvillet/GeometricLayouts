import { TestBed } from '@angular/core/testing';
import { TriangleService } from './triangle.service';
import { HttpClientModule, HttpHeaders } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Triangle } from '../model/triangle';

describe('TriangleService', () => {
  let triangleService: TriangleService = null;
  let httpMock: HttpTestingController = null;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TriangleService],
      imports: [HttpClientModule, HttpClientTestingModule]
    });

    triangleService = TestBed.get(TriangleService);
    httpMock = TestBed.get(HttpTestingController);
  });

  it('should be created', () => {
    expect(TriangleService.URL).toBeTruthy();
    expect(TriangleService.URL).toEqual('/api/triangles');
  });

  describe('#getTriangle', () => {
    it('should send a REST call to get a Triangle', () => {
      const requestData = 'B5';
      const mockResponse = new Triangle();

      triangleService.getTriangle(requestData).subscribe((response: any) => {
        expect(response).toEqual(mockResponse);
      });

      const request = httpMock.expectOne(TriangleService.URL + '/' + requestData);
      expect(request.request.method).toEqual('GET');

      request.flush(mockResponse);
      httpMock.verify();
    });
  });

  describe('#getTriangle', () => {
    it('should send a REST call to get a triangle for the given name', () => {
      const requestData = 'B5';
      const mockResponse = new Triangle();

      triangleService.getTriangle(requestData).subscribe((response: any) => {
        expect(response).toEqual(mockResponse);
      });

      const request = httpMock.expectOne(TriangleService.URL + '/' + requestData);
      expect(request.request.method).toEqual('GET');

      request.flush(mockResponse);
      httpMock.verify();
    });
  });

  describe('#getName', () => {
    it('should send a REST call to get the name of the given triangle', () => {
      const requestData = {
        v1: { x: 20, y: 20 },
        v2: { x: 20, y: 10 },
        v3: { x: 30, y: 20 }
      };
      const mockResponse = 'B5';

      triangleService.getName(requestData).subscribe((response: any) => {
        expect(response).toEqual(mockResponse);
      });

      const request = httpMock.expectOne(TriangleService.URL + '/name');
      expect(request.request.body).toEqual(requestData);
      expect(request.request.method).toEqual('POST');

      request.flush(mockResponse);
      httpMock.verify();
    });
  });
});
