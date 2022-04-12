import { Component, OnInit } from '@angular/core';
import { Request } from '../request';
import { RequestService } from '../request.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  requests: Request[] = [];

  constructor(private requestService: RequestService) { }

  getRequests(): void {
    this.requestService.getRequests()
      .subscribe(requests => this.requests = requests.slice(0, 4));
  }

  ngOnInit(): void {
    this.getRequests();
  }
}
