import { Component } from '@angular/core';
import { ClientModel } from "./Model/ClientModel";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  currentClient: ClientModel = null;

  onClientChange(client: ClientModel){
    this.currentClient = client;
    console.log(client);
  }

  // call this method for clear all tasks if selected client was hidden
  onFilterData(newClients: ClientModel[]){
    console.log(newClients);
    if(this.currentClient){
      if(!newClients.find((c) => { return c.id === this.currentClient.id } )){
        this.currentClient = null;
      }
    }
  }
}
