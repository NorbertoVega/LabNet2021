export interface Product {
    id: number;
    name: string;
    supplierId: number;
    categoryId: number;
    quantityPUnit: string;
    unitPrice: number;
    unitsInStock: number;
    unitsOnOrder: number;
    reorderLevel: number;
    discontinued: number;
}