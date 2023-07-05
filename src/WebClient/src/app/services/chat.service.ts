import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  private hub: HubConnection;

  constructor() {
    this.hub = new HubConnectionBuilder()
      .withUrl(environment.chatUrl)
      .build();
  }
}
