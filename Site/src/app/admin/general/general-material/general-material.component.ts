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

import { GeneralMaterialService, GeneralMaterial } from './general-material-service';
import { LookupService, Lookup, LookupType } from '../../system/lookup/lookup.service';
import { VendorService, Vendor } from '../vendor/vendor.service';

@Component({
  selector: 'app-general-material',
  templateUrl: './general-material.component.html',
  styleUrls: ['./general-material.component.css'],
  providers: [LookupService, VendorService, GeneralMaterialService]
})
export class GeneralMaterialComponent implements OnInit {
  lookupDataSource: Array<Lookup>;
  colorDataSource: Array<Lookup>;
  materialTypeDataSource: Array<Lookup>;
  uomDataSource: Array<Lookup>;
  vendorDataSource: Array<Vendor>;

  showInactive = false;
  showAuditFields = false;

  generalMaterialsDataSource: Array<GeneralMaterial>;

  constructor(public lookupService: LookupService, public vendorService: VendorService,
              public generalMaterialService: GeneralMaterialService) {
    this.refreshData();
    // console.log(this.selectedUser);
    console.log('Refreshing Data');
   }

   refreshData(deselect?: boolean) {
    console.log('Refresh Data of General Materials');
      this.generalMaterialService.loadGeneralMaterialData('rwflowers').subscribe(res => this.generalMaterialsDataSource = res);
      this.lookupService.loadLookupData('rwflowers').subscribe(res => this.filterLookupData(res));
      this.vendorService.loadVendorData('rwflowers').subscribe(res => this.vendorDataSource = res);
   }

   updateInactive(d) {
    this.generalMaterialService.showInactive = this.showInactive;
    this.refreshData();
  }
   filterLookupData(data) {
     console.log('Filtering Lookup Data'); console.log(data);
     this.lookupDataSource = data;
     this.colorDataSource = data.filter(item => item.lookupType.typeDescription === 'Color');
     this.materialTypeDataSource = data.filter(item => item.lookupType.typeDescription === 'Material Type');
     this.uomDataSource = data.filter(item => item.lookupType.typeDescription === 'UOM');
   }

   create(d) {
    const newGeneralMaterial: GeneralMaterial = {
      id: 0,
      materialProduct: d.data.materialProduct,
      colorId: d.data.colorId,
      materialTypeId: d.data.materialTypeId,
      quantity: d.data.quantity,
      uomId: d.data.uomId,
      vendorId: d.data.vendorId,
      isActive: d.data.isActive,
      created: d.data.created,
      createdBy: d.data.createdBy,
      lastUpdated: d.data.lastUpdated,
      lastUpdatebBy: d.data.lastUpdatebBy
    };

    console.log('Creating User');
    console.log(newGeneralMaterial);

    this.generalMaterialService.createGeneralMaterial(newGeneralMaterial, 'rwflowers').subscribe();
    this.refreshData();
  }

  save(d) {
    console.log('Saving General Material Change');
    console.log(d);

    const updGenMaterial: GeneralMaterial = {
      id: d.key.id,
      vendorId: d.newData.vendorId === undefined ? d.oldData.vendorId : d.newData.vendorId,
      materialProduct: d.newData.materialProduct === undefined ? d.oldData.materialProduct : d.newData.materialProductemail,
      colorId: d.newData.colorId === undefined ? d.oldData.colorId : d.newData.colorId,
      materialTypeId: d.newData.materialTypeId === undefined ? d.oldData.materialTypeId : d.newData.materialTypeId,
      quantity: d.newData.quantity === undefined ? d.oldData.quantity : d.newData.quantity,
      uomId: d.newData.uomId === undefined ? d.oldData.uomId : d.newData.uomId,
      isActive: d.newData.isActive === undefined ? d.oldData.isActive : d.newData.isActive,
      created: d.newData.created === undefined ? d.oldData.created : d.newData.created,
      createdBy: d.newData.createdBy === undefined ? d.oldData.createdBy : d.newData.createdBy,
      lastUpdated: d.newData.lastUpdated === undefined ? d.oldData.lastUpdated : d.newData.lastUpdated,
      lastUpdatebBy: d.newData.lastUpdatebBy === undefined ? d.oldData.lastUpdatebBy : d.newData.lastUpdatebBy
    };

    this.generalMaterialService.saveGeneralMaterial(updGenMaterial, 'rwflowers').subscribe(res => this.refreshData());
   }

   deactivateUser(d) {
    console.log('Deactivating General Material');
    console.log(d);

    this.generalMaterialService.deactivateGeneralMaterial(d.key.id, 'rwflowers').subscribe(res => this.refreshData());
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
      console.log('GeneralMaterialData'); console.log(this.generalMaterialsDataSource);
      console.log('LookupDataSource'); console.log(this.lookupDataSource);
    }

    ngOnInit(
  ) {
  }
}

