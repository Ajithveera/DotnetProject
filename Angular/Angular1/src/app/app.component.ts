import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './services/employee.service';
import { subscribeOn } from 'rxjs';
import { employee } from './Models/Employee';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  EmployeeArray :employee[]=[];

  EmployeeFormGroup :FormGroup;

  constructor(private empservice : EmployeeService,private fb :FormBuilder){
    this.EmployeeFormGroup=this.fb.group({
      id : [""],
      name : [""],
      mobileNo : [""],
      emailId : [""]

    })
  }
  ngOnInit(): void {
  this.empservice.GetEmployee().subscribe(Response=>{
    console.log(Response);
    this.EmployeeArray=Response;

  })
}
onsubmit(){
console.log (this.EmployeeFormGroup.value);
this.empservice.CreateEmployee(this.EmployeeFormGroup.value).subscribe(response=>{
  console.log(response);

})

}
title = 'Angular1';
}