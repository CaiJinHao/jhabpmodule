import { ModuleWithProviders, NgModule } from '@angular/core';
import { JH_IDENTITY_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class JhIdentityConfigModule {
  static forRoot(): ModuleWithProviders<JhIdentityConfigModule> {
    return {
      ngModule: JhIdentityConfigModule,
      providers: [JH_IDENTITY_ROUTE_PROVIDERS],
    };
  }
}
