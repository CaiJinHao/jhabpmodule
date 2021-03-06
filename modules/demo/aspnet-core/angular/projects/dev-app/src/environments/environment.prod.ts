import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'YourProjectName',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44375',
    redirectUri: baseUrl,
    clientId: 'YourProjectName_App',
    responseType: 'code',
    scope: 'offline_access YourProjectName',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44375',
      rootNamespace: 'YourCompany.YourProjectName',
    },
    YourProjectName: {
      url: 'https://localhost:44379',
      rootNamespace: 'YourCompany.YourProjectName',
    },
  },
} as Environment;
