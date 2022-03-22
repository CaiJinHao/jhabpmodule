import { AccountConfigModule } from '@abp/ng.account/config';
import { CoreModule } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { IdentityConfigModule } from '@abp/ng.identity/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';
import { ThemeBasicModule } from '@abp/ng.theme.basic';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { YourProjectNameConfigModule } from '@your-company/your-project-name/config';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { AppLayoutComponent } from './components/app-layout/app-layout.component';
import { MenuSiderComponent } from './menu-sider/menu-sider.component';
import { NzMenuModule } from 'ng-zorro-antd/menu';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
      sendNullsAsQueryParam: false,
      skipGetAppConfiguration: false,
    }),
    ThemeSharedModule.forRoot(),
    AccountConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    TenantManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    YourProjectNameConfigModule.forRoot(),
    ThemeBasicModule.forRoot(),
    NzLayoutModule,NzMenuModule
  ],
  providers: [APP_ROUTE_PROVIDER],
  declarations: [AppComponent, AppLayoutComponent, MenuSiderComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
