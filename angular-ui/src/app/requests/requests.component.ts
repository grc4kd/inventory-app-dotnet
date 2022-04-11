import { Component, OnInit } from '@angular/core';
import { Request } from '../request'

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {
  request: Request = {
    id: 1,
    name: 'request for "24697-013-01-05"',
    quantity: 22
  };

  constructor() { }

  ngOnInit(): void {
  }

}
