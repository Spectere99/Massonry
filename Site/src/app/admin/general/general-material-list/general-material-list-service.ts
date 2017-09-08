import { Injectable } from '@angular/core';
import { Http, HttpModule, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

export class GeneralMaterial {
    id: number;
    vendorId: number;
    materialProduct: string;
    colorId: number;
    materialTypeId: number;
    quantity: number;
    uomId: number;
    isActive: boolean;
    created: string;
    createdBy: string;
    lastUpdated: string;
    lastUpdatebBy: string;
}

@Injectable()
export class GeneralMaterialListService {
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

    loadGeneralMaterialData(userId): Observable<any> {
        return this.http.get(this.baseURL + '/GeneralMaterial', {headers: this.getHeaders(userId)})
        .map(res => {
            return res.json();
        });
    }

    createGeneralMaterial(data: GeneralMaterial, userId: string) {
        return this.http.post(this.baseURL + '/GeneralMaterial', JSON.stringify(data),
        {headers: this.getHeaders(userId)});
    }

    saveGeneralMaterial(data: GeneralMaterial, userId: string) {
        return this.http.put(this.baseURL + '/GeneralMaterial', JSON.stringify(data),
        {headers: this.getHeaders(userId)});
    }

    deactivateGeneralMaterial(id: number, userId: string) {
        return this.http.delete(this.baseURL + '/GeneralMaterial/' + id, {headers: this.getHeaders(userId)});
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
