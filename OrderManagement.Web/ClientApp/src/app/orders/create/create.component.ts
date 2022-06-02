import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Vendor } from "../vendor";
import { OrdersService } from "../orders.service";
import { VendorsService } from "../vendors.service";
import { Order } from '../order';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  vendors: Vendor[] = [];
  createForm;

  constructor(
    public ordersService: OrdersService,
    public vendorsService: VendorsService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.createForm = this.formBuilder.group({
      id: 0,
      orderNumber: ['', Validators.required],
      orderAmount: ['', Validators.required],
      shopNumber: ['', Validators.required],
      orderDate: [''],
      vendorId: [''],
    });
  }

  ngOnInit(): void {
    this.vendorsService.getVendors().subscribe((data: Vendor[]) => {
      this.vendors = data;
    });
  }

  onSubmit(formData) {
    console.log(formData.value);
    formData.value.orderDate = new Date(formData.value.orderDate);
    this.ordersService.createOrder(formData.value).subscribe(res => {
      this.router.navigateByUrl('orders/list');
    });
  }
}
