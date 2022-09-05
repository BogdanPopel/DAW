import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {LocationsRoutingModule} from "./locations-routing.module";
import { LocationsComponent } from './locations/locations.component';
import {MatTableModule} from "@angular/material/table";
import {MatIconModule} from "@angular/material/icon";
import { LocationComponent } from './location/location.component';



@NgModule({
  declarations: [
    LocationsComponent,
    LocationComponent
  ],
  imports: [
    CommonModule,
    LocationsRoutingModule,
    MatTableModule,
    MatIconModule
  ]
})
export class LocationsModule { }
