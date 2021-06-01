import { Injectable } from '@angular/core';

import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  _url = "/api/Product"

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get(this._url); 
  }

  getOneProduct(_id) {
    return this.http.get(this._url+'/'+_id , _id);
  }

  addProduct(product) {

    return this.http.post(this._url, product);
  }

  editProduct(updateProduct) {

    console.log(updateProduct.ProductID)
    return this.http.put(this._url+'/'+ updateProduct.ProductId , updateProduct);
  }

  deleteProduct(_id) {
 
    console.log(this._url+'/'+_id)
    return this.http.delete(this._url+'/'+_id , _id);
  }

}
