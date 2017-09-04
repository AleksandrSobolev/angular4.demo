import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'phone-csv',
  templateUrl: './phone-csv.component.html',
  styleUrls: ['./phone-csv.component.css']
})
export class PhoneCsvComponent implements OnInit {
  @Input('phones') phones: string;
  public parsedPhones: string[];
  constructor() { }

  ngOnInit() {
    this.parsedPhones = this.phones.split(";");
  }

}
