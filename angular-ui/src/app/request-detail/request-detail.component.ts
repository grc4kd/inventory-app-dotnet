import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Request } from '../request';
import { RequestService } from '../request.service';
import { InventoryItem } from '../inventory-item';

@Component({
  selector: 'app-request-detail',
  templateUrl: './request-detail.component.html',
  styleUrls: ['./request-detail.component.css']
})
export class RequestDetailComponent implements OnInit {
  request: Request | undefined;
  currentItem: InventoryItem | undefined;

  constructor(
    private route: ActivatedRoute,
    private requestService: RequestService
  ) { }

  ngOnInit(): void {
    this.getRequest();
  }

  getRequest(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.requestService.getRequest(id)
      .subscribe(request => this.request = request);
  }
}
