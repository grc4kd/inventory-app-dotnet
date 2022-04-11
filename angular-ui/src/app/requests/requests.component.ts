import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {
  request = 'request for "24697-013-01-05"';
  constructor() { }

  ngOnInit(): void {
  }

}
