import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequest } from '../models/requests/login-request';
import { RegisterRequest } from '../models/requests/register-request';
import { environment } from 'src/environments/environment';
import { UserResponse } from '../models/responses/user-response';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  API = environment.apiUrl;
  constructor(private http: HttpClient) { }

  authenticate(model: LoginRequest) {
    try {
      return this.http.post<UserResponse>(`${this.API}/auth/login`, model)
    } catch (error) {
      return of(null)
    }
  }

  register(model: RegisterRequest) {

  }
}
