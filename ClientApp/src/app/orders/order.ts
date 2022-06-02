import { Vendor } from "./vendor";

export interface Order {
  id: number;
  orderDate: any;
  orderNumber: number;
  orderAmount: number;
  vendorId?: number;
  vendor?: Vendor;
  shopNumber: number;
  checked?: boolean;
}
