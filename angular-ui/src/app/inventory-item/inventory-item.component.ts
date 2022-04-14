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

  // TODO: use this function to conditionally display a message
  // property binding and attribute directives, I think? need more bootcamp
  checkStock(requestedKernels: number): boolean {
    if (this.inventoryItem != null) {
      const kernels = this.inventoryItem.kernels;
      if (kernels < requestedKernels)
        return false;
      else
        return true;
    }
    return false; // no kernels to count
  }

  goBack(): void {
    this.location.back();
  }
}
