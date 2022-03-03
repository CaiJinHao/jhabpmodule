import { ModuleWithProviders, NgModule } from '@angular/core';
import { JH_PERMISSION_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class JhPermissionConfigModule {
  static forRoot(): ModuleWithProviders<JhPermissionConfigModule> {
    return {
      ngModule: JhPermissionConfigModule,
      providers: [JH_PERMISSION_ROUTE_PROVIDERS],
    };
  }
}
