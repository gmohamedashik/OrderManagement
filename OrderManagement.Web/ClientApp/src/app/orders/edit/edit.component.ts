import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Order } from "../order";
import { Vendor } from "../vendor";
import { OrdersService } from "../orders.service";
import { VendorsService } from "../vendors.service";

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  id: number;
  order: Order;
  vendors: Vendor[] = [];
  editForm;

  constructor(
    public ordersService: OrdersService,
    public vendorsService: VendorsService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.editForm = this.formBuilder.group({
      id: [''],
      orderNumber: ['', Validators.required],
      orderAmount: ['', Validators.required],
      shopNumber: ['', Validators.required],
      orderDate : [''],
      vendorId: [''],
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['orderId'];

    this.vendorsService.getVendors().subscribe((data: Vendor[]) => {
      this.vendors = data;
    });

    this.ordersService.getOrder(this.id).subscribe((data: Order) => {
      this.order = data;
      data.orderDate = data.orderDate.split("T")[0];
      this.editForm.patchValue(data);
    });
  }

  onSubmit(formData) {
    console.log(formData.value);
    this.ordersService.updateOrder(this.id, formData.value).subscribe(res => {
      this.router.navigateByUrl('orders/list');
    });
  }
}
