import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Http, HttpModule, Headers, RequestMethod, RequestOptions } from '@angular/http';
import { FormsModule, NgModel } from '@angular/forms';

import { DevExtremeModule } from 'devextreme-angular';

import { AppComponent } from './app.component';
import { AdminComponent } from './admin/admin.component';
import { SecurityComponent } from './admin/security/security.component';
import { UserComponent } from './admin/security/user/user.component';
import { RolesComponent } from './admin/security/roles/roles.component';
import { PermissionsComponent } from './admin/security/permissions/permissions.component';
import { SystemComponent } from './admin/system/system.component';
import { LookupComponent } from './admin/system/lookup/lookup.component';
import { GeneralComponent } from './admin/general/general.component';
import { GeneralMaterialComponent } from './admin/general/general-material/general-material.component';
import { VendorComponent } from './admin/general/vendor/vendor.component';
import { GeneralPlanComponent } from './admin/general/general-plan/general-plan.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    SecurityComponent,
    UserComponent,
    RolesComponent,
    PermissionsComponent,
    SystemComponent,
    LookupComponent,
    GeneralComponent,
    GeneralMaterialComponent,
    VendorComponent,
    GeneralPlanComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    DevExtremeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
