export interface Product {
    id: number;
    name: string;
    unitPrice: number;
    unitsInStock: number;
    supplierId: number;
    categoryId: number;
    quantityPUnit: string;
    unitsOnOrder: number;
    reorderLevel: number;
    discontinued: number;
}