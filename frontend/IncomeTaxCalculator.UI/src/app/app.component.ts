import { TaxCalculationDTO } from './models/tax-calculation.dto';
import { Component } from '@angular/core';
import { TaxCalculationService } from './services/tax-calculation.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  /**
   *
   */
  constructor(private taxService: TaxCalculationService) {


  }
  title = 'IncomeTaxCalculator.UI';
  public salary = new FormControl(0);
  public taxCalculation: TaxCalculationDTO | undefined;
  public onCalculateClick() {
    console.log(this.salary.value);
    this.taxService.calculateTax(this.salary.value).subscribe(resp=>{
      console.log(resp);
      this.taxCalculation = resp;
    });
  }
}
