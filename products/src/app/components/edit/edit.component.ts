import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';

import {Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

import { MatDialog } from '@angular/material/dialog';

import { ProductService } from '../../services/product.service';
import { Product } from '../../models/Products';


@Component({
  selector: 'app-edit',
  template: 'passed in {{ data.editId }}',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  public form: FormGroup;

  get nameCtrl():AbstractControl {
    return this.form.get('name');
  }
  get supplierIdCtrl():AbstractControl {
    return this.form.get('supplierId');
  }
  get categoryIdCtrl():AbstractControl {
    return this.form.get('categoryId');
  }
  get quantityCtrl():AbstractControl {
    return this.form.get('quantity');
  }
  get unitPriceCtrl():AbstractControl {
    return this.form.get('unitPrice');
  }
  get unitsStockCtrl():AbstractControl {
    return this.form.get('unitsStock');
  }
  get unitsOnOrderCtrl():AbstractControl {
    return this.form.get('unitsOnOrder');
  }
  get reorderLevelCtrl():AbstractControl {
    return this.form.get('reorderLevel');
  }
  get discontinuedCtrl():AbstractControl {
    return this.form.get('discontinued');
  }

  constructor(private formBuilder: FormBuilder, @Inject(MAT_DIALOG_DATA) public data: {editId: string}, private listService: ProductService, private matDialog: MatDialog) { }

  private auxProduct;

  ngOnInit(): void {

    var _id = +this.data.editId;
    this.listService.getOneProduct(_id).subscribe((resp:any) =>{
      
      this.auxProduct = resp

      this.form = this.formBuilder.group ({
        name: [this.auxProduct.ProductName], 
        supplierId: [this.auxProduct.SupplierID],
        categoryId: [this.auxProduct.CategoryID],
        quantity: [this.auxProduct.QuantityPerUnit],
        unitPrice: [this.auxProduct.UnitPrice],
        unitsStock: [this.auxProduct.UnitsInStock],
        unitsOnOrder: [this.auxProduct.UnitsOnOrder],
        reorderLevel: [this.auxProduct.ReorderLevel],
        discontinued: [this.auxProduct.Discontinued]
      });

    });
    console.log('aux: '+ this.auxProduct);


    this.form = this.formBuilder.group ({
      name: [''], 
      supplierId: [''],
      categoryId: [''],
      quantity: [''],
      unitPrice: [''],
      unitsStock: [''],
      unitsOnOrder: [''],
      reorderLevel: [''],
      discontinued: ['']
    });
  }

  onSubmit():void {
    console.log(this.form.value)
  }

  onClickLimpiar():void {
    if (this.nameCtrl) {
      this.nameCtrl.setValue('');
    }
    if (this.supplierIdCtrl) {
      this.supplierIdCtrl.setValue('');
    }
    if (this.categoryIdCtrl) {
      this.categoryIdCtrl.setValue('');
    }
    if (this.quantityCtrl) {
      this.quantityCtrl.setValue('');
    }
    if (this.unitPriceCtrl) {
      this.unitPriceCtrl.setValue('');
    }
    if (this.unitsStockCtrl) {
      this.unitsStockCtrl.setValue('');
    }
    if (this.unitsOnOrderCtrl) {
      this.unitsOnOrderCtrl.setValue('');
    }
    if (this.reorderLevelCtrl) {
      this.reorderLevelCtrl.setValue('');
    }
    if (this.discontinuedCtrl) {
      this.discontinuedCtrl.setValue('');
    }
  }

  editProduct() {
    const _id = +this.data.editId;
    console.log('id que va a modificar: '+ _id)

    this.listService.editProduct({
      ProductId: _id, 
      ProductName: this.nameCtrl.value,
      SupplierID: this.supplierIdCtrl.value,
      CategoryID: this.categoryIdCtrl.value,
      QuantityPerUnit: this.quantityCtrl.value,
      UnitPrice: this.unitPriceCtrl.value,
      UnitsInStock: this.unitsStockCtrl.value,
      UnitsOnOrder: this.unitsOnOrderCtrl.value,
      ReorderLevel: this.reorderLevelCtrl.value,
      Discontinued: this.discontinuedCtrl.value
    }).subscribe();

    this.matDialog.closeAll();
  }
}

      
