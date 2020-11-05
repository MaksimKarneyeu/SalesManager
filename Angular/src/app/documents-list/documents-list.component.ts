import { Component, OnInit } from "@angular/core";
import { DocumentService } from "../shared/services/document.service";
import Document from "../shared/models/Document";

@Component({
	selector: "app-documents-list",
	templateUrl: "./documents-list.component.html",
	styleUrls: ["./documents-list.component.css"]
})
export class DocumentsListComponent implements OnInit {
	documents: Array<Document>;

	constructor(private documentService: DocumentService) {}

	ngOnInit() {
		this.documentService.getDocuments().subscribe(data => {
			this.documents = data;
		});
	}
}
