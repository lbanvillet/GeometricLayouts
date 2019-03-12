import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isNameCalculatorVisible: boolean;

  onShowNameCalculator() {
    this.isNameCalculatorVisible = true;
  }

  onShowTriangleGenerator() {
    this.isNameCalculatorVisible = false;
  }
}
