import { Component, OnInit } from '@angular/core';
import { InventoryItem } from '../inventory-item';
import { InventoryItemService } from '../inventory-item.service';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {
  inventory: InventoryItem[] = [];

  constructor(private inventoryItemService: InventoryItemService) { }

  getInventory(): void {
    this.inventoryItemService.getInventory()
      .subscribe(inventory => this.inventory = inventory)
  }

  ngOnInit(): void {
    this.getInventory();
  }
}
