import { Component, OnInit } from '@angular/core';
import { TriangleService } from '../http/triangle.service';
import { Triangle } from '../model/triangle';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

@Component({
  selector: 'app-triangle-generator',
  templateUrl: './triangle-generator.component.html',
  styleUrls: ['./triangle-generator.component.scss', '../app.component.scss']
})
export class TriangleGeneratorComponent implements OnInit {
  triangleName: string;
  triangle: Triangle;
  errorMessage: string;

  constructor(private triangleService: TriangleService, private spinnerService: Ng4LoadingSpinnerService) { }

  ngOnInit() {
  }

  onShowTriangle() {
    this.spinnerService.show();
    this.triangle = undefined;
    this.errorMessage = undefined;

    this.triangleService.getTriangle(this.triangleName).subscribe(
      triangle => this.triangle = triangle,
      error => this.errorMessage = (error.status === 400 ? 'The requested name is invalid' : 'An unexpected error occurred'),
      () => this.spinnerService.hide()
    );
  }
}
