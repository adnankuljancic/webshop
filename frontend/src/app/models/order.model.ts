import { OrderItem } from "./order-item.model";

export class Order {
    constructor(public userId: number, public orderItemsList: OrderItem[]){}
}