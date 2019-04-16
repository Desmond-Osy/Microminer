import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';


@Component({
    selector: 'kwicplus',
    templateUrl: './kwicplus.component.html'
})

export class KwicplusComponent {
    input: String = "";
    output: String = "";
    list: String[] = this.input.split("\n");
    processingDetail: ProcessingDetail = {data: "initial" };

    jsonInput = {
        "input": this.input.trim(),
    }

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        
    }

    public runKwic() {  
        
        //update the input field with data from control
        this.jsonInput.input = this.input.trim();

        this.http.post(this.baseUrl + 'api/kwic', this.jsonInput).subscribe(result => {
            if (result.status == 200) {
                
                this.processingDetail = result.json() as ProcessingDetail;
                var res = this.processingDetail.data.toString();

                res = res.replace("[", "");
                res = res.replace("]", "");
                for (let word of res.split(',')) {
                    res = res.replace(",", "\n");
                    res = res.replace("\"", "");
                    res = res.replace("\"", "");      
                }

                this.output = res;
            }
        }, error => console.error(error));
    }
    
}

interface ProcessingDetail {
    data: any;
}

