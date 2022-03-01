import { ModuleWithProviders, NgModule } from '@angular/core';
import { JH_MENU_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class JhMenuConfigModule {
  static forRoot(): ModuleWithProviders<JhMenuConfigModule> {
    return {
      ngModule: JhMenuConfigModule,
      providers: [JH_MENU_ROUTE_PROVIDERS],
    };
  }
}
