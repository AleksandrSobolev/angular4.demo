import { ClientModel } from './../Model/ClientModel';
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'client-panel',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  @Input('clientModel') client: ClientModel;
  @Output('clickByClient') clickByClient = new EventEmitter();
  @Input('isSelected') isSelected: boolean;

  constructor() { }

  ngOnInit() {
  }

  onClick(client: ClientModel){
    this.clickByClient.emit(client);
    this.isSelected = true;
  }

}
