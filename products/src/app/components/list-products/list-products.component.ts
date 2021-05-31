import { Component, OnInit } from '@angular/core';

import { NewProductComponent } from '../new-product/new-product.component';
import { EditComponent } from '../edit/edit.component';

import { MatDialog } from '@angular/material/dialog';

import { ProductService } from '../../services/product.service';
import { Product } from '../../models/Products';

import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.css']
})
export class ListProductsComponent implements OnInit {

  productList$: Observable<Product[]>;

  dataSource : Product[] 

  constructor(private matDialog: MatDialog, private listService: ProductService) { }

  ngOnInit(): void {
    this.dataSource = this.listService.getProducts();
    this.productList$ = this.listService.getProductList$();
    this.productList$.subscribe(products => this.dataSource = products);
  }

  openDialog(): void {
    this.matDialog.open(NewProductComponent);
  }

  openEditDialog(_id): void {
    this.matDialog.open(EditComponent, {data: {editId: _id}});
  }

  deleteProduct(_id): void {
    this.listService.deleteProduct(_id);
  }
}
