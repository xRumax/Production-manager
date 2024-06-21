import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Environment {
  base_url: string = 'http://localhost:5170/api';

  constructor() {}
}
