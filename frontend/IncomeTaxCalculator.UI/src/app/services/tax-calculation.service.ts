import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaxCalculationDTO } from '../models/tax-calculation.dto';

@Injectable({
  providedIn: 'root'
})
export class TaxCalculationService {

  constructor(private http:HttpClient) {

   }
   public calculateTax(salary: any):Observable<TaxCalculationDTO>
     {
        return this.http.post<TaxCalculationDTO>("https://localhost:7054/api/TaxCalculation", {salary:salary})
     }
}
