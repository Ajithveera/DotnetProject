import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { employee } from '../Models/Employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpclient : HttpClient) { }

   baseurl="http://localhost:5017/api/Employee";
   

  GetEmployee () :Observable<employee[]>
  {
      return this.httpclient.get<employee[]>(this.baseurl)
  }
  CreateEmployee (emp : employee) : Observable<employee>
  {
    emp.id="00000000-0000-0000-0000-000000000000";
      return this.httpclient.post<employee>(this.baseurl,emp)
  }
  
}
