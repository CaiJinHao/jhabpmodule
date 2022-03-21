import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class YourProjectNameService {
  apiName = 'YourProjectName';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/YourProjectName/sample' },
      { apiName: this.apiName }
    );
  }
}
