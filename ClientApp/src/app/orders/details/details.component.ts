import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Order } from "../order";
import { OrdersService } from "../orders.service";

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  id: number;
  order: Order;

  constructor(
    public ordersService: OrdersService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['orderId'];
    this.ordersService.getOrder(this.id).subscribe((data: Order) => {
      this.order = data;
    });
  }
}
