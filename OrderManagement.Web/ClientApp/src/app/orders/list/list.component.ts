import { Component, OnInit } from '@angular/core';
import { Order } from "../order";
import { OrdersService } from "../orders.service";

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  msg: string;
  clss: string; 
  orders: Order[] = [];
  constructor(public ordersService: OrdersService) { }

  ngOnInit(): void {
    this.ordersService.getOrders().subscribe((data: Order[]) => {
      this.orders = data;
    });
  }

  isAllCheckBoxChecked() {
    return this.orders.every(p => p.checked);
  }

  checkAllCheckBox(ev) { 
    this.orders.forEach(x => x.checked = ev.target.checked)
  }

  deleteOrder(id) {
    this.ordersService.deleteOrder(id).subscribe(res => {
      this.orders = this.orders.filter(item => item.id !== id);
    });
  }

  deleteOrders(): void {
    const selectedOrders = this.orders.filter(order => order.checked).map(p => p.id);
    console.log(selectedOrders);
    if (selectedOrders && selectedOrders.length > 0) {
      this.ordersService.deleteOrders(selectedOrders)
        .subscribe(res => {
          this.clss = 'grn';
          this.msg = 'Order successfully deleted';
          this.ordersService.getOrders().subscribe((data: Order[]) => {
            this.orders = data;
          });
        }, err => {
          this.clss = 'rd';
          this.msg = 'Something went wrong during deleting orders';
        }
        );
    } else {
      this.clss = 'rd';
      this.msg = 'You must select at least one order';
    }
  }

}
