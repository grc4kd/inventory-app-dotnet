import { Component, OnInit } from '@angular/core';
import { Request } from '../request';
import { RequestService } from '../request.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})

export class RequestsComponent implements OnInit {
  requests: Request[] = [];

  constructor(private requestService: RequestService) { }

  getRequests(): void {
    this.requestService.getRequests()
      .subscribe(requests => this.requests = requests);
  }

  ngOnInit(): void {
    this.getRequests();
  }
}
