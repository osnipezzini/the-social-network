import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest } from '../models/requests/login-request';
import { RegisterRequest } from '../models/requests/register-request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  authenticate(model: LoginRequest){

  }

  register(model: RegisterRequest) {

  }
}
