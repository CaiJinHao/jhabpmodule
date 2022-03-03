import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class JhPermissionService {
  apiName = 'JhPermission';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/JhPermission/sample' },
      { apiName: this.apiName }
    );
  }
}
