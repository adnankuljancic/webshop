import { ProductSize } from "./product_size.model";

export class CartItem {
    constructor(public cartItemId?: number, public userId?: number, public productSizeId?: number, public quantity?: number, public productSize?: ProductSize,public checked?: boolean){};
}