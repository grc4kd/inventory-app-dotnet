import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { InventoryItem } from '../inventory-item';
import { InventoryItemService } from '../inventory-item.service';

@Component({
  selector: 'app-inventory-item',
  templateUrl: './inventory-item.component.html',
  styleUrls: ['./inventory-item.component.css']
})
export class InventoryItemComponent implements OnInit {
  inventoryItem: InventoryItem | undefined;

  constructor(
    private route: ActivatedRoute,
    private inventoryService: InventoryItemService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getInventory();
  }

  getInventory(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.inventoryService.getInventoryItem(id)
      .subscribe(inventory => this.inventoryItem = inventory);
  }

  checkStock(requestedKernels: number) {
    if (this.inventoryItem) {
      let stockSufficient = this.inventoryService.checkStock(this.inventoryItem.id, requestedKernels);

      return stockSufficient;
    }

    return false;
  }

  goBack(): void {
    this.location.back();
  }
}
