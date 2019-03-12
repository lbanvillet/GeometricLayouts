import { Component, OnInit } from '@angular/core';
import { TriangleService } from '../http/triangle.service';
import { Triangle } from '../model/triangle';
import { Vertex } from '../model/vertex';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

@Component({
  selector: 'app-name-calculator',
  templateUrl: './name-calculator.component.html',
  styleUrls: ['./name-calculator.component.scss', '../app.component.scss']
})
export class NameCalculatorComponent implements OnInit {
  triangle: Triangle;
  triangleName: string;
  errorMessage: string;

  constructor(private triangleService: TriangleService, private spinnerService: Ng4LoadingSpinnerService) {
  }

  ngOnInit() {
    this.triangle = {
      v1: new Vertex(),
      v2: new Vertex(),
      v3: new Vertex()
    };
  }

  onShowName() {
    this.spinnerService.show();
    this.triangleName = undefined;
    this.errorMessage = undefined;

    this.triangleService.getName(this.triangle).subscribe(
      response => this.triangleName = response.name,
      error => {
        switch (error.status) {
          case 400:
            this.errorMessage = 'The format of the parameters in incorrect';
            break;
          case 404:
            this.errorMessage = 'The entered coordinates do not belong to any triangle';
            break;
          default:
            this.errorMessage = 'An unexpected error occurred';
        }
      },
      () => this.spinnerService.hide()
    );
  }
}
