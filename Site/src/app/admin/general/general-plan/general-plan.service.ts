import { Injectable } from '@angular/core';
import { Http, HttpModule, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

export class GeneralPlan {
    id: number;
    planName: string;
    elevationLookupId: number;
    garageTypeLookupId: number;
    isActive: boolean;
    created: string;
    createdBy: string;
    lastUpdated: string;
    lastUpdatebBy: string;
}

@Injectable()
export class GeneralPlanService {
    private baseURL = 'http://localhost:55407/api';
    lookupTypes;
    lookups;
    showInactive = false;

    constructor(private http: Http) {
    }

    private getHeaders(userId) {
        const headers = new Headers({ 'Accept': 'application/json' });
        headers.append('Content-Type', 'application/json; charset=UTF-8');
        headers.append('userid', userId);
        headers.append('showInactive', this.showInactive.toString());
        return headers;
    }

    loadGeneralPlanData(userId): Observable<any> {
        return this.http.get(this.baseURL + '/GeneralPlan', {headers: this.getHeaders(userId)})
        .map(res => {
            return res.json();
        });
    }

    createGeneralPlan(data: GeneralPlan, userId: string) {
        console.log('In createGeneralPlan');
        console.log(data);
        return this.http.post(this.baseURL + '/GeneralPlan', JSON.stringify(data),
            {headers: this.getHeaders(userId)});
    }


    saveGeneralPlan(data: GeneralPlan, userId: string) {
        console.log('In saveGeneralPlan');
        console.log(data);
        return this.http.put(this.baseURL + '/GeneralPlan', JSON.stringify(data),
            {headers: this.getHeaders(userId)});
    }

    deactivateGeneralPlan(id: number, userId: string) {
        console.log('Deactivating GeneralPlan');
        console.log(id);
        return this.http.delete(this.baseURL + '/GeneralPlan/' + id, {headers: this.getHeaders(userId)});
    }

    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    }

    private handleErrorObservable (error: Response | any) {
        console.error(error.message || error);
        return Observable.throw(error.message || error);
    }
}
