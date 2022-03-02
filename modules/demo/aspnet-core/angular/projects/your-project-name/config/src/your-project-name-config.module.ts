import { ModuleWithProviders, NgModule } from '@angular/core';
import { YOUR_PROJECT_NAME_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class YourProjectNameConfigModule {
  static forRoot(): ModuleWithProviders<YourProjectNameConfigModule> {
    return {
      ngModule: YourProjectNameConfigModule,
      providers: [YOUR_PROJECT_NAME_ROUTE_PROVIDERS],
    };
  }
}
