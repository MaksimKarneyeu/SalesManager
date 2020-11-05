import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import Document from "../models/Document";
import { BaseService } from "../services/base.service";

@Injectable({
	providedIn: "root"
})
export class DocumentService extends BaseService {
	public UPLOAD_CSV_API = `${this.API}/Documents/GetDocumentsAsync`;

	constructor(private httpClient: HttpClient) {
		super();
	}

	getDocuments(): Observable<Array<Document>> {
		return this.httpClient.get<Array<Document>>(this.UPLOAD_CSV_API);
	}
}
