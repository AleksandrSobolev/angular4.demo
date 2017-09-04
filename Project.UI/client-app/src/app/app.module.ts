import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule, ErrorHandler } from '@angular/core';

import { AppComponent } from './app.component';
import { ClientsListComponent } from './clients-list/clients-list.component';
import { ClientService } from "./services/client.Service";
import { HttpClientModule } from "@angular/common/http";
import { ClientComponent } from './client/client.component';
import { TaskComponent } from './task/task.component';
import { TaskService } from "./services/task.Service";
import { AppErrorHandler } from "./common/app-error-handler";
import { LongTextPipe } from "./common/Pipes/long-text.pipe";
import { PhoneCsvComponent } from './phone-csv/phone-csv.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientsListComponent,
    ClientComponent,
    TaskComponent,
    LongTextPipe,
    PhoneCsvComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    ClientService,
    TaskService,
    { provide: ErrorHandler, useClass: AppErrorHandler }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
