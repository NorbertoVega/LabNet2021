import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';

import { ProductService } from '../../services/product.service';

import { MatDialog } from '@angular/material/dialog';

var nextId = 6;

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {

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


  constructor(private formBuilder: FormBuilder, private listService: ProductService, private dialog: MatDialog ) { }

  ngOnInit(): void {

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

  
  addProduct() {
    this.listService.addProduct({
      id: nextId, name: this.nameCtrl.value, supplierId: this.supplierIdCtrl.value, categoryId: this.categoryIdCtrl.value, quantityPUnit: this.quantityCtrl.value, unitPrice: this.unitPriceCtrl.value,
      unitsInStock: this.unitsStockCtrl.value, unitsOnOrder: this.unitsOnOrderCtrl.value, reorderLevel: this.reorderLevelCtrl.value, discontinued: this.discontinuedCtrl.value
    });
    nextId = nextId + 1;
    this.dialog.closeAll();
  }

}
