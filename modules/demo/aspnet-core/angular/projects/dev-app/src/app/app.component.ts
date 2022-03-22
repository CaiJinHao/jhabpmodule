import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <app-app-layout></app-app-layout>
    <!-- <abp-dynamic-layout></abp-dynamic-layout> -->
  `,
})
export class AppComponent {}
