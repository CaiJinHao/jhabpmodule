import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { JhMenuComponent } from './components/jh-menu.component';
import { JhMenuRoutingModule } from './jh-menu-routing.module';

@NgModule({
  declarations: [JhMenuComponent],
  imports: [CoreModule, ThemeSharedModule, JhMenuRoutingModule],
  exports: [JhMenuComponent],
})
export class JhMenuModule {
  static forChild(): ModuleWithProviders<JhMenuModule> {
    return {
      ngModule: JhMenuModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<JhMenuModule> {
    return new LazyModuleFactory(JhMenuModule.forChild());
  }
}
