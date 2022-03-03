import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { JhPermissionComponent } from './components/jh-permission.component';
import { JhPermissionRoutingModule } from './jh-permission-routing.module';

@NgModule({
  declarations: [JhPermissionComponent],
  imports: [CoreModule, ThemeSharedModule, JhPermissionRoutingModule],
  exports: [JhPermissionComponent],
})
export class JhPermissionModule {
  static forChild(): ModuleWithProviders<JhPermissionModule> {
    return {
      ngModule: JhPermissionModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<JhPermissionModule> {
    return new LazyModuleFactory(JhPermissionModule.forChild());
  }
}
