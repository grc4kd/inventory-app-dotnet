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
  selectedRequest?: Request;
  onSelect(request: Request): void {
    this.selectedRequest = request;
  }

  constructor(private requestService: RequestService) { }

  getRequests(): void {
    this.requests = this.requestService.getRequests();
  }

  ngOnInit(): void {
    this.getRequests();
  }
}
