import { Injectable } from '@angular/core';
import { Http, HttpModule, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

export class Address {
    id: number;
    name: string;
    address1: string;
    address2: string;
    city: string;
    state: string;
    zip: string;
    isActive: boolean;
    created: string;
    createdBy: string;
    lastUpdated: string;
    lastUpdatebBy: string;
}

@Injectable()
export class AddressService {
    private baseURL = 'http://localhost:55407/api';
    generalMaterials;
    showInactive = false;

    constructor (private http: Http) {
    }

    private getHeaders(userId) {
        const headers = new Headers({ 'Accept': 'application/json' });
        headers.append('Content-Type', 'application/json; charset=UTF-8');
        headers.append('userid', userId);
        headers.append('showInactive', this.showInactive.toString());
        return headers;
    }

    loadAddressData(userId): Observable<any> {
        return this.http.get(this.baseURL + '/Address', {headers: this.getHeaders(userId)})
        .map(res => {
            return res.json();
        });
    }

    createAddress(data: Address, userId: string) {
        return this.http.post(this.baseURL + '/Address', JSON.stringify(data),
        {headers: this.getHeaders(userId)});
    }

    saveAddress(data: Address, userId: string) {
        return this.http.put(this.baseURL + '/Address', JSON.stringify(data),
        {headers: this.getHeaders(userId)});
    }

    deactivateAddress(id: number, userId: string) {
        return this.http.delete(this.baseURL + '/Address/' + id, {headers: this.getHeaders(userId)});
    }

    private extractData(res: Response) {
        const body = res.json();
        return body.data || {};
    }

    private handleErrorObservable (error: Response | any) {
        console.error(error.message || error);
        return Observable.throw(error.message || error);
    }
}
