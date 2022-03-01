import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { JhIdentityComponent } from './components/jh-identity.component';
import { JhIdentityRoutingModule } from './jh-identity-routing.module';

@NgModule({
  declarations: [JhIdentityComponent],
  imports: [CoreModule, ThemeSharedModule, JhIdentityRoutingModule],
  exports: [JhIdentityComponent],
})
export class JhIdentityModule {
  static forChild(): ModuleWithProviders<JhIdentityModule> {
    return {
      ngModule: JhIdentityModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<JhIdentityModule> {
    return new LazyModuleFactory(JhIdentityModule.forChild());
  }
}
