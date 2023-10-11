import { ProductSize } from "./product_size.model";

export class NewProduct {
    constructor(
        public productId?: number,
        public productName?: string, 
        public productDescription?: string,
        public image?: string, 
        public brandId?: number,
        public categoryId?: number,
        public productSizeList?: ProductSize[]) {}
}