import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { Http, HttpModule, Headers, RequestMethod, RequestOptions } from '@angular/http';
import { NgModel } from '@angular/forms';
import { NgFor } from '@angular/common';
import { DxDataGridModule,
         DxDataGridComponent } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';

import DataSource from 'devextreme/data/data_source';
import ArrayStore from 'devextreme/data/array_store';
import CustomStore from 'devextreme/data/custom_store';
import 'rxjs/add/operator/toPromise';

import { VendorService, Vendor } from '../vendor/vendor.service';
import { AddressService, Address } from '../../_services/address.service';

@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css'],
  providers: [VendorService, AddressService]
})
export class VendorComponent implements OnInit {
  vendorDataSource: Array<Vendor>;
  addressDataSource: Array<Address>;

  showInactive = false;
  showAuditFields = false;

  constructor(public vendorService: VendorService, public addressService: AddressService ) {
      this.refreshData();
   }

   refreshData(deselect?: boolean) {
    console.log('Refresh Vendor Data');
    this.addressService.loadAddressData('rwflowers').subscribe(res => this.addressDataSource = res);
    this.vendorService.loadVendorData('rwflowers').subscribe(res => this.vendorDataSource = res);
   }

   updateInactive(d) {
    this.vendorService.showInactive = this.showInactive;
    this.refreshData();
  }
   filterLookupData(data) {
   }

   create(d) {
    const newVendor: Vendor = {
      id: 0,
      name: d.data.name,
      shippingAddressId: d.data.shippingAddressId,
      billingAddressId: d.data.billingAddressId,
      isActive: d.data.isActive,
      created: d.data.created,
      createdBy: d.data.createdBy,
      lastUpdated: d.data.lastUpdated,
      lastUpdatebBy: d.data.lastUpdatebBy
    };

    console.log('Creating Vendor');
    console.log(newVendor);

    this.vendorService.createVendor(newVendor, 'rwflowers').subscribe();
    this.refreshData();
  }

  save(d) {
    console.log('Saving Vendor Change');
    console.log(d);

    const updVendor: Vendor = {
      id: d.key.id,
      name: d.newData.name === undefined ? d.oldData.name : d.newData.name,
      shippingAddressId: d.newData.shippingAddressId === undefined ? d.oldData.shippingAddressId : d.newData.shippingAddressId,
      billingAddressId: d.newData.billingAddressId === undefined ? d.oldData.billingAddressId : d.newData.billingAddressId,
      isActive: d.newData.isActive === undefined ? d.oldData.isActive : d.newData.isActive,
      created: d.newData.created === undefined ? d.oldData.created : d.newData.created,
      createdBy: d.newData.createdBy === undefined ? d.oldData.createdBy : d.newData.createdBy,
      lastUpdated: d.newData.lastUpdated === undefined ? d.oldData.lastUpdated : d.newData.lastUpdated,
      lastUpdatebBy: d.newData.lastUpdatebBy === undefined ? d.oldData.lastUpdatebBy : d.newData.lastUpdatebBy
    };

    this.vendorService.saveVendor(updVendor, 'rwflowers').subscribe(res => this.refreshData());
   }

   deactivate(d) {
    console.log('Deactivating Vendor');
    console.log(d);

    this.vendorService.deactivateVendor(d.key.id, 'rwflowers').subscribe(res => this.refreshData());
   }
   moveEditColumnToLeft(e) {
    e.component.columnOption('command:edit',
    {
      visibleIndex: -1,
      width: 80
    });
  }

  formatCommandColumn(e) {
    if (e.rowType === 'data' && e.column.command === 'edit') {
      const isEditing = e.row.isEditing;
      const links = e.cellElement.find('.dx-link');

      links.text('');

      if (isEditing) {
        links.filter('.dx-link-save').addClass('dx-icon-save');
        links.filter('.dx-link-cancel').addClass('dx-icon-revert');
      } else {
        links.filter('.dx-link-edit').addClass('dx-icon-edit');
        links.filter('.dx-link-delete').addClass('dx-icon-trash');
      }
    }
    }
    selectionChanged(data) {
      console.log(this.vendorDataSource);
      console.log(this.addressDataSource);
    }
  ngOnInit() {
  }

}
