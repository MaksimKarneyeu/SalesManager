import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import Sale from "../shared/models/Sale";
import SaleService from "../shared/services/sale.service";
import { MatSelectChange } from "@angular/material/select";

@Component({
	selector: "app-aggregation",
	templateUrl: "./aggregation.component.html",
	styleUrls: ["./aggregation.component.css"]
})
export class AggregationComponent implements OnInit {
	totalOrders;
	totalProfit;
	documentID;
	selectedYear: Date;
	selectedCountry;
	sales: Array<Sale>;
	countries: Array<string>;
	years: Array<Date>;
	constructor(private route: ActivatedRoute, private saleService: SaleService) {}

	//event handler for the select element's change event
	getSelectedYear(event: MatSelectChange) {
		this.selectedYear = event.value;
		this.aggreagate();
	}

	getSelectedCountry(event: MatSelectChange) {
		this.selectedCountry = event.value;
		this.aggreagate();
	}

	ngOnInit(): void {
		this.route.paramMap.subscribe(params => {
			this.documentID = params.get("documentID");
		});
		this.saleService.getSalesByDocumentId(this.documentID).subscribe(data => {
			this.sales = data;
			this.countries = data.map(x => x.country);
			this.years = data.map(x => x.orderDate);
		});
	}

	aggreagate() {
		if (this.selectedCountry && this.selectedYear) {
			const data = this.sales.filter(
				x =>
					x.country == this.selectedCountry &&
					x.orderDate.getFullYear === this.selectedYear.getFullYear
			);
			this.totalOrders = data.length;
			this.totalProfit = data.map(x => x.totalProfit).reduce((a, b) => a + b, 0);
		}
	}
}
