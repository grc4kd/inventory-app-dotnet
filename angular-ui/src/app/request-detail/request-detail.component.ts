import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Request } from '../request';
import { RequestService } from '../request.service';

@Component({
  selector: 'app-request-detail',
  templateUrl: './request-detail.component.html',
  styleUrls: ['./request-detail.component.css']
})
export class RequestDetailComponent implements OnInit {
  request: Request | undefined;

  constructor(
    private route: ActivatedRoute,
    private requestService: RequestService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getRequest();
  }

  getRequest(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.requestService.getRequest(id)
      .subscribe(request => this.request = request);
  }

  goBack(): void {
    this.location.back();
  }
}
