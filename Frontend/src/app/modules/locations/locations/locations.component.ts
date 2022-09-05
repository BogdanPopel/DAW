import { Component, OnInit } from '@angular/core';
import {LocationsService} from "../../../services/locations.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-locations',
  templateUrl: './locations.component.html',
  styleUrls: ['./locations.component.scss']
})
export class LocationsComponent implements OnInit {

  public locations: any;
  public displayedColumns: string[] = ['id', 'name', 'adress'];

  constructor(
    private locationService: LocationsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getLocations();
  }

  public getLocations(): void{
    this.locationService.getAllLocations().subscribe( (result) => {
      this.locations = result;
    })
}
 public seeAdress(id: number) : void{
    this.router.navigate(['/location', id])
 }
}
