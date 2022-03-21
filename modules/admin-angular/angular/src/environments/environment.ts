import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'YourProjectName',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:7001',
    redirectUri: baseUrl,
    clientId: 'YourProjectName_App',
    responseType: 'code',
    scope: 'offline_access YourProjectName',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44306',
      rootNamespace: 'YourCompany.YourProjectName',
    },
  },
} as Environment;
