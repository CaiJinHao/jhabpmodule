import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'angulartest',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:6201',
    redirectUri: baseUrl,
    clientId: 'angulartest_App',
    responseType: 'code',
    scope: 'offline_access angulartest',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:6201',
      rootNamespace: 'angulartest',
    },
  },
} as Environment;
