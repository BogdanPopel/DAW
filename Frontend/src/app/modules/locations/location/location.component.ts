import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {LocationsService} from "../../../services/locations.service";

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.scss']
})
export class LocationComponent implements OnInit, OnDestroy {
  public id: number | undefined;
  private sub: any;
  constructor(
    private route: ActivatedRoute,
    private locationsService: LocationsService
  ) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; //(+) -> transforma string in numar
      console.log(this.id)
      if(this.id){
      this.getLocationDetails();
      }
    })
  }

  public getLocationDetails(): void{
    this.locationsService.getAdress(this.id).subscribe((result) =>{
      console.log(result);
    })
}

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
