import { OrderItem } from "./order-item.model";

export class OrderHistory {
    constructor(public createdDate: any, public orderId: number, public orderItemsList: OrderItem[], public userId: number){}
}