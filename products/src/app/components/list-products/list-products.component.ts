import { Component, OnInit } from '@angular/core';

import { NewProductComponent } from '../new-product/new-product.component';
import { EditComponent } from '../edit/edit.component';

import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.css']
})
export class ListProductsComponent implements OnInit {

  dataSource = [
    {id: 1, name: 'Chai', supplierId: 1, categoryId: 1, quantityPUnit: '10 boxes x 20 bags', unitPrice: 18.00, unitsInStock: 39, unitsOnOrder: 0, reorderLevel: 10, discontinued: 0 },
    {id: 1, name: 'Chai', supplierId: 1, categoryId: 1, quantityPUnit: '10 boxes x 20 bags', unitPrice: 18.00, unitsInStock: 39, unitsOnOrder: 0, reorderLevel: 10, discontinued: 0 },
    {id: 1, name: 'Chai', supplierId: 1, categoryId: 1, quantityPUnit: '10 boxes x 20 bags', unitPrice: 18.00, unitsInStock: 39, unitsOnOrder: 0, reorderLevel: 10, discontinued: 0 },
    {id: 1, name: 'Chai', supplierId: 1, categoryId: 1, quantityPUnit: '10 boxes x 20 bags', unitPrice: 18.00, unitsInStock: 39, unitsOnOrder: 0, reorderLevel: 10, discontinued: 0 }
  ]
  displayedColumns: string[] = ['id', 'name', 'supplierId', 'categoryId','quantityPUnit','unitPrice',
    'unitsInStock','unitsOnOrder','reorderLevel','discontinued','edit','delete'];

  constructor(private matDialog: MatDialog) { }

  ngOnInit(): void {
  }

  openDialog(): void {
    this.matDialog.open(NewProductComponent);
  }

  openEditDialog(): void {
    this.matDialog.open(EditComponent)
  }

}
