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

import { GeneralPlanService, GeneralPlan } from '../general-plan/general-plan.service';
import { LookupService, Lookup, LookupType } from '../../system/lookup/lookup.service';

@Component({
  selector: 'app-general-plan',
  templateUrl: './general-plan.component.html',
  styleUrls: ['./general-plan.component.css'],
  providers: [LookupService, GeneralPlanService]
})
export class GeneralPlanComponent implements OnInit {
  lookupDataSource: Array<Lookup>;
  elevationDataSource: Array<Lookup>;
  garageTypeDataSource: Array<Lookup>;

  showInactive = false;
  showAuditFields = false;

  generalPlanDataSource: Array<GeneralPlan>;

  constructor(public lookupService: LookupService, public generalPlanService: GeneralPlanService) {
      this.refreshData();
      // console.log(this.selectedUser);
      console.log('Refreshing Data');
  }
  refreshData(deselect?: boolean) {
    console.log('Refresh Data of General Plan');
      this.generalPlanService.loadGeneralPlanData('rwflowers').subscribe(res => this.generalPlanDataSource = res);
      this.lookupService.loadLookupData('rwflowers').subscribe(res => this.filterLookupData(res));
   }

   updateInactive(d) {
    this.generalPlanService.showInactive = this.showInactive;
    this.refreshData();
  }
   filterLookupData(data) {
     console.log('Filtering Lookup Data'); console.log(data);
     this.lookupDataSource = data;
     this.elevationDataSource = data.filter(item => item.lookupType.typeDescription === 'Elevation Type');
     this.garageTypeDataSource = data.filter(item => item.lookupType.typeDescription === 'Garage Type');
   }

   create(d) {
    const newGeneralPlan: GeneralPlan = {
      id: 0,
      planName: d.data.planName,
      elevationLookupId: d.data.elevationLookupId,
      garageTypeLookupId: d.data.garageTypeLookupId,
      isActive: d.data.isActive,
      created: d.data.created,
      createdBy: d.data.createdBy,
      lastUpdated: d.data.lastUpdated,
      lastUpdatebBy: d.data.lastUpdatebBy
    };

    console.log('Creating User');
    console.log(newGeneralPlan);

    this.generalPlanService.createGeneralPlan(newGeneralPlan, 'rwflowers').subscribe();
    this.refreshData();
  }

  save(d) {
    console.log('Saving General Plan Change');
    console.log(d);

    const updGenPlan: GeneralPlan = {
      id: d.key.id,
      planName: d.newData.planName === undefined ? d.oldData.planName : d.newData.planName,
      elevationLookupId: d.newData.elevationLookupId === undefined ? d.oldData.elevationLookupId : d.newData.elevationLookupId,
      garageTypeLookupId: d.newData.garageTypeLookupId === undefined ? d.oldData.garageTypeLookupId : d.newData.garageTypeLookupId,
      isActive: d.newData.isActive === undefined ? d.oldData.isActive : d.newData.isActive,
      created: d.newData.created === undefined ? d.oldData.created : d.newData.created,
      createdBy: d.newData.createdBy === undefined ? d.oldData.createdBy : d.newData.createdBy,
      lastUpdated: d.newData.lastUpdated === undefined ? d.oldData.lastUpdated : d.newData.lastUpdated,
      lastUpdatebBy: d.newData.lastUpdatebBy === undefined ? d.oldData.lastUpdatebBy : d.newData.lastUpdatebBy
    };

    this.generalPlanService.saveGeneralPlan(updGenPlan, 'rwflowers').subscribe(res => this.refreshData());
   }

   deactivate(d) {
    console.log('Deactivating General Plan');
    console.log(d);

    this.generalPlanService.deactivateGeneralPlan(d.key.id, 'rwflowers').subscribe(res => this.refreshData());
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
      console.log('GeneralPlanData'); console.log(this.generalPlanDataSource);
      console.log('LookupDataSource'); console.log(this.lookupDataSource);
    }

  ngOnInit() {
  }

}
