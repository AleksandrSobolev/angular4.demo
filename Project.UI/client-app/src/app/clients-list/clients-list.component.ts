import { ClientModel } from './../Model/ClientModel';
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { ClientService } from "../services/client.Service";

@Component({
  selector: 'clients-list',
  templateUrl: './clients-list.component.html',
  styleUrls: ['./clients-list.component.css']
})
export class ClientsListComponent implements OnInit {
  private _originalClients: ClientModel[];
  public clients: ClientModel[];
  public clientCities: Array<string>;
  public firstNameFilterValue: string;
  public cityFilterValue: string;
  
  @Input('selectedClientId') selectedClientId: number;
  @Output('changeClient') selectNewClient = new EventEmitter();
  @Output('filterClients') filterClients = new EventEmitter();

  constructor(private clientService: ClientService) { 
    this.clientCities = new Array<string>();
  }

  ngOnInit() {
    this.clientService.getAll<ClientModel>()
      .subscribe((data: ClientModel[]) => {
        this._originalClients = data;
        this.clients = this._originalClients;
        this.mapCitiesFromClient(this.clients);
      });
  }
  
  onSelect(client: ClientModel){
    this.selectNewClient.emit(client);
    this.selectedClientId = client.id;
  }

  mapCitiesFromClient(dataClients: ClientModel[]){
    let cities: string[] = dataClients.map((cl) => {
      return cl.address;
    });

    let newCities = new Array<string>();
    cities.forEach((city) => {
      if(!newCities.includes(city)) {
        newCities.push(city);
      }
    });

    if(newCities.length > 1){
      this.clientCities = newCities;
    }
  }

  onFilter(){
    let filterByName = (this.firstNameFilterValue) ? this.firstNameFilterValue.toLowerCase() : '';
    let filterByCity = (this.cityFilterValue) ? this.cityFilterValue.toLowerCase() : '';

    this.clients = this._originalClients.filter((client) => {

      if(!client.firstName.toLowerCase().startsWith(filterByName)) {
        return false;
      }
      else {
        if(filterByCity.length > 0 && !(client.address.toLowerCase() === filterByCity)) {
          return false;
        }
      }

      return true;
    });

    this.filterClients.emit(this.clients);

    this.mapCitiesFromClient(this.clients);
  }

}
