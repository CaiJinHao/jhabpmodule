import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { YourProjectNameComponent } from './components/your-project-name.component';
import { YourProjectNameRoutingModule } from './your-project-name-routing.module';

@NgModule({
  declarations: [YourProjectNameComponent],
  imports: [CoreModule, ThemeSharedModule, YourProjectNameRoutingModule],
  exports: [YourProjectNameComponent],
})
export class YourProjectNameModule {
  static forChild(): ModuleWithProviders<YourProjectNameModule> {
    return {
      ngModule: YourProjectNameModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<YourProjectNameModule> {
    return new LazyModuleFactory(YourProjectNameModule.forChild());
  }
}
