import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import Sale from "../shared/models/Sale";
import { FormBuilder } from "@angular/forms";
import SaleService from "../shared/services/sale.service";
import { Location } from "@angular/common";

@Component({
	selector: "app-sale-edit",
	templateUrl: "./sale-edit.component.html",
	styleUrls: ["./sale-edit.component.css"]
})
export class SaleEditComponent implements OnInit {
	checkoutForm;
	saleID;
	sale: Sale;
	constructor(
		private route: ActivatedRoute,
		private saleService: SaleService,
		private formBuilder: FormBuilder,
		private location: Location
	) {
		this.checkoutForm = this.formBuilder.group({
			region: "",
			country: "",
			itemType: "",
			salesChannel: "",
			orderPriority: "",
			orderDate: "",
			orderID: "",
			shipDate: "",
			unitsSold: "",
			unitPrice: "",
			unitCost: "",
			totalRevenue: "",
			totalCost: "",
			totalProfit: ""
		});
	}

	ngOnInit(): void {
		this.route.paramMap.subscribe(params => {
			this.saleID = params.get("saleID");
		});
		this.saleService.getSaleById(this.saleID).subscribe(data => {
			this.sale = data;
			this.checkoutForm = this.formBuilder.group(data);
		});
	}

	onSubmit(saleData) {
		saleData["id"] = this.saleID;
		this.saleService.updateSale(saleData).subscribe(data => {
			this.sale = data;
		});
	}

	onDelete() {
		this.saleService.deleteSale(this.saleID).subscribe(() => {
			this.location.back();
		});
	}
}
