import { AfterViewInit, Component, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { ActivatedRoute } from "@angular/router";
import Sale from "../shared/models/Sale";
import SaleService from "../shared/services/sale.service";

@Component({
	selector: "app-sales-list",
	templateUrl: "./sales-list.component.html",
	styleUrls: ["./sales-list.component.css"]
})
export class SalesListComponent implements AfterViewInit {
	documentID;
	sales: Array<Sale>;
	displayedColumns: string[] = [
		"region",
		"country",
		"itemType",
		"salesChannel",
		"orderPriority",
		"orderDate",
		"orderID",
		"shipDate",
		"unitsSold",
		"unitPrice",
		"unitCost",
		"totalRevenue",
		"totalCost",
		"totalProfit"
	];
	dataSource;
	constructor(private route: ActivatedRoute, private saleService: SaleService) {}

	@ViewChild(MatPaginator) paginator: MatPaginator;
	@ViewChild(MatSort) sort: MatSort;

	applyFilter(event: Event) {
		const filterValue = (event.target as HTMLInputElement).value;
		this.dataSource.filter = filterValue.trim().toLowerCase();
		this.dataSource.filterPredicate = (data: Sale, filter: string) => {
			return data.country.toLowerCase().includes(filter.toLowerCase());
		};
		if (this.dataSource.paginator) {
			this.dataSource.paginator.firstPage();
		}
	}

	ngAfterViewInit() {
		this.route.paramMap.subscribe(params => {
			this.documentID = params.get("documentID");
		});
		this.saleService.getSalesByDocumentId(this.documentID).subscribe(data => {
			this.dataSource = new MatTableDataSource<Sale>(data);
			this.dataSource.paginator = this.paginator;
			this.dataSource.sort = this.sort;
		});
	}
}
