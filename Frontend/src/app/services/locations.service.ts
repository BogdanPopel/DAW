import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class LocationsService {
  public url = 'https://localhost:44341/api/Location';
  constructor(
    private http: HttpClient
  ) { }

  public getAllLocations(): Observable<any>{
      return this.http.get<any>(this.url);
  }
  public getAdress(id: number | undefined): Observable<any>{
     return this.http.get(`${this.url}/byId/${id}`);
  }
}
