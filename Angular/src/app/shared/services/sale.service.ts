import { Injectable } from "@angular/core";
import { HttpClient, HttpEvent, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { BaseService } from "../services/base.service";
import Sale from "../models/Sale";

@Injectable({
	providedIn: "root"
})
export default class SaleService extends BaseService {
	public GET_SALES_BY_DOCUMENT_ID = `${
		this.API
	}/sales/GetSalesByDocumentIdAsync`;
	public GET_SALES_BY_ID = `${this.API}/sales/GetSaleByIdAsync`;
	public UPDATE_SALE = `${this.API}/sales/UpdateSaleAsync`;
	public DELETE_SALE = `${this.API}/sales/DeleteSaleAsync`;
	public UPLOAD_CSV = `${this.API}/SalesImport/uploadcsv`;
	constructor(private httpClient: HttpClient) {
		super();
	}

	uploadCsv(fd): Observable<HttpEvent<FormData>> {
		const req = new HttpRequest("Post", this.UPLOAD_CSV, fd, {
			reportProgress: true
		});
		req.headers.append("Content-Type", "application/json");
		return this.httpClient.request(req);
	}

	getSalesByDocumentId(documentID: number): Observable<Array<Sale>> {
		return this.httpClient.get<Array<Sale>>(
			`${this.GET_SALES_BY_DOCUMENT_ID}/?id=${documentID}`
		);
	}

	getSaleById(saleID: number): Observable<Sale> {
		return this.httpClient.get<Sale>(`${this.GET_SALES_BY_ID}/?id=${saleID}`);
	}

	updateSale(sale: Sale): Observable<Sale> {
		return this.httpClient.put<Sale>(`${this.UPDATE_SALE}`, sale);
	}
	deleteSale(saleID: number): Observable<Sale> {
		return this.httpClient.delete<Sale>(`${this.DELETE_SALE}/?id=${saleID}`);
	}
}
