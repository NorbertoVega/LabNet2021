import { Injectable } from '@angular/core';

import { Product } from '../models/Products';

import { Observable, of } from 'rxjs';
import { Subject } from 'rxjs';



const ProductList = [
  {id: 1, name: 'Chai', supplierId: 1, categoryId: 1, quantityPUnit: '10 boxes x 20 bags', unitPrice: 18.00, unitsInStock: 39, unitsOnOrder: 0, reorderLevel: 10, discontinued: 0 },
  {id: 2, name: 'Chai2', supplierId: 1, categoryId: 1, quantityPUnit: '20 boxes x 20 bags', unitPrice: 19.00, unitsInStock: 40, unitsOnOrder: 10, reorderLevel: 10, discontinued: 0 },
  {id: 3, name: 'Chai3', supplierId: 1, categoryId: 1, quantityPUnit: '30 boxes x 20 bags', unitPrice: 20.00, unitsInStock: 41, unitsOnOrder: 1, reorderLevel: 0, discontinued: 0 },
  {id: 4, name: 'Chai4', supplierId: 1, categoryId: 1, quantityPUnit: '40 boxes x 20 bags', unitPrice: 21.00, unitsInStock: 42, unitsOnOrder: 2, reorderLevel: 10, discontinued: 0 },
  {id: 5, name: 'Chai5(the cinco)', supplierId: 1, categoryId: 1, quantityPUnit: '40 boxes x 20 bags', unitPrice: 21.00, unitsInStock: 42, unitsOnOrder: 2, reorderLevel: 10, discontinued: 0 }

]


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private productList$ = new Subject<Product[]>();

  getProductList$(): Observable<Product[]> {
    return this.productList$.asObservable();
  }

  constructor() { }

  getProducts() {
    return ProductList;
  }

  getOneProduct(_id) {
    return ProductList.find(product => product.id ===_id);
  }

  addProduct(product: Product) {
    
    ProductList.push(product);
    this.productList$.next(ProductList);
  }

  editProduct(newProduct: Product) {
    const index = ProductList.findIndex(product => product.id === newProduct.id)
    ProductList[index] = newProduct;
    this.productList$.next(ProductList);
  }

  deleteProduct(_id) {
    const index = ProductList.findIndex(prod => prod.id === _id);
    ProductList.splice(index,1)
    this.productList$.next(ProductList);
    console.log(ProductList)
  }

}
