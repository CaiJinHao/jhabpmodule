import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class JhMenuService {
  apiName = 'JhMenu';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/JhMenu/sample' },
      { apiName: this.apiName }
    );
  }
}
