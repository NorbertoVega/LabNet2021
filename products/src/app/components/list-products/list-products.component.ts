import { Component, OnInit } from '@angular/core';

import { NewProductComponent } from '../new-product/new-product.component';
import { EditComponent } from '../edit/edit.component';

import { MatDialog } from '@angular/material/dialog';

import { ProductService } from '../product.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.css'],
  providers: [ProductService]
})
export class ListProductsComponent implements OnInit {

  public dataSource = [];

  constructor(private matDialog: MatDialog, private listService: ProductService) { }

  ngOnInit() {

    this.listService.getProducts().subscribe((resp:any) => {
      this.dataSource = resp;
      this.listService.productList = resp;  
      this.dataSource = this.listService.productList;
    });

  }

  openDialog(): void {
    this.matDialog.open(NewProductComponent);
  }

  openEditDialog(_id): void {
    this.matDialog.open(EditComponent, { data: { editId: _id } });
  }

  async deleteProduct(_id) {
    this.listService.deleteProduct(_id).subscribe(
      res =>  window.location.reload(),
      error => console.log(error.message),
      () => console.log('Borrado con exito')
    );
    }
}
