import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LocationsComponent} from "./locations/locations.component";

const routes: Routes = [
  {
path:'',
redirectTo:'locations',
    pathMatch:'full'
},
  {
  path: 'locations',
component: LocationsComponent
},
  {
    path: 'location/:id',
  component: LocationsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LocationsRoutingModule { }
