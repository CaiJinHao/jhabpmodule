import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'JhMenu',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44324',
    redirectUri: baseUrl,
    clientId: 'JhMenu_App',
    responseType: 'code',
    scope: 'offline_access JhMenu',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44324',
      rootNamespace: 'Jh.Abp.JhMenu',
    },
    JhMenu: {
      url: 'https://localhost:44344',
      rootNamespace: 'Jh.Abp.JhMenu',
    },
  },
} as Environment;
