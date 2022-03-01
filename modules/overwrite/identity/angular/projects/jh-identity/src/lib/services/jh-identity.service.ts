import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class JhIdentityService {
  apiName = 'JhIdentity';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/JhIdentity/sample' },
      { apiName: this.apiName }
    );
  }
}
