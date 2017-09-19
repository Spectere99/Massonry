import { Injectable } from '@angular/core';
import { Http, HttpModule, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

export class Vendor {
    id: number;
    name: string;
    shippingAddressId: number;
    billingAddressId: number;
    isActive: boolean;
    created: string;
    createdBy: string;
    lastUpdated: string;
    lastUpdatebBy: string;
}

@Injectable()
export class VendorService {
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

    loadVendorData(userId): Observable<any> {
        return this.http.get(this.baseURL + '/Vendor', {headers: this.getHeaders(userId)})
        .map(res => {
            return res.json();
        });
    }

    createVendor(data: Vendor, userId: string) {
        console.log('In createVendor');
        console.log(data);
        return this.http.post(this.baseURL + '/Vendor', JSON.stringify(data),
            {headers: this.getHeaders(userId)});
    }


    saveVendor(data: Vendor, userId: string) {
        console.log('In saveVendor');
        console.log(data);
        return this.http.put(this.baseURL + '/Vendor', JSON.stringify(data),
            {headers: this.getHeaders(userId)});
    }

    deactivateVendor(id: number, userId: string) {
        console.log('Deactivating Vendor');
        console.log(id);
        return this.http.delete(this.baseURL + '/Vendor/' + id, {headers: this.getHeaders(userId)});
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
