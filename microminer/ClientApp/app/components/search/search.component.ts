import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';


@Component({
    selector: 'search',
    templateUrl: './search.component.html'
})

export class SearchComponent {
    description: String = "";
    searchResult: String = "";
    resultDetail: ResultDetail  = { data: "" };

    jsonInput = {
        "input": this.description.trim(),
    }

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {

    }

    public search() {

        
        this.jsonInput.input = this.description.trim();
        if (this.jsonInput.input != "") {
            this.http.post(this.baseUrl + 'api/search', this.jsonInput).subscribe(result => {
                if (result.status == 200) {

                    this.resultDetail = result.json() as ResultDetail;
                    var res = this.resultDetail.data.toString();

                    res = res.replace("[", "");
                    res = res.replace("]", "");
                    for (let word of res.split(',')) {
                        res = res.replace(",", "\n");
                        res = res.replace("\"", "");
                        res = res.replace("\"", "");
                    }

                    this.searchResult = res;
                }

            }, error => console.error(error));
        }
    }

}

interface ResultDetail {
    data: any;
}
