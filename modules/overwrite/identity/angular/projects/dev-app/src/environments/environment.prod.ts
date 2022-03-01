import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'JhIdentity',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44354',
    redirectUri: baseUrl,
    clientId: 'JhIdentity_App',
    responseType: 'code',
    scope: 'offline_access JhIdentity',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44354',
      rootNamespace: 'Jh.Abp.JhIdentity',
    },
    JhIdentity: {
      url: 'https://localhost:44373',
      rootNamespace: 'Jh.Abp.JhIdentity',
    },
  },
} as Environment;
