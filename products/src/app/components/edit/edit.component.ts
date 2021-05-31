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

  private auxProduct : Product;

  ngOnInit(): void {

    var _id = +this.data.editId;
    this.auxProduct = this.listService.getOneProduct(_id);

    this.form = this.formBuilder.group ({
      name: [this.auxProduct.name], 
      supplierId: [this.auxProduct.supplierId],
      categoryId: [this.auxProduct.categoryId],
      quantity: [this.auxProduct.quantityPUnit],
      unitPrice: [this.auxProduct.unitPrice],
      unitsStock: [this.auxProduct.unitsInStock],
      unitsOnOrder: [this.auxProduct.unitsOnOrder],
      reorderLevel: [this.auxProduct.reorderLevel],
      discontinued: [this.auxProduct.discontinued]
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

    this.listService.editProduct({
      id: _id, name: this.nameCtrl.value, supplierId: this.supplierIdCtrl.value, categoryId: this.categoryIdCtrl.value, quantityPUnit: this.quantityCtrl.value, unitPrice: this.unitPriceCtrl.value,
      unitsInStock: this.unitsStockCtrl.value, unitsOnOrder: this.unitsOnOrderCtrl.value, reorderLevel: this.reorderLevelCtrl.value, discontinued: this.discontinuedCtrl.value
    });

    this.matDialog.closeAll();
  }
}
