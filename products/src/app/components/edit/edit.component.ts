import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  public form: FormGroup;

  get nameCtrl():AbstractControl {
    return this.form.get('name');
  }
  get suplierIdCtrl():AbstractControl {
    return this.form.get('suplierId');
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

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {

    this.form = this.formBuilder.group ({
      name: [''], 
      suplierId: [''],
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
    if (this.suplierIdCtrl) {
      this.suplierIdCtrl.setValue('');
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

}
