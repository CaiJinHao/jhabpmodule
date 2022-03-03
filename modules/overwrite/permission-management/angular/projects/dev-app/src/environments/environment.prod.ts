import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'JhPermission',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44371',
    redirectUri: baseUrl,
    clientId: 'JhPermission_App',
    responseType: 'code',
    scope: 'offline_access JhPermission',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44371',
      rootNamespace: 'Jh.Abp.JhPermission',
    },
    JhPermission: {
      url: 'https://localhost:44384',
      rootNamespace: 'Jh.Abp.JhPermission',
    },
  },
} as Environment;
