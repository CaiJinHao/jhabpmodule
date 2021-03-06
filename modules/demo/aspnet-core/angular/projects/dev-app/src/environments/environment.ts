import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'YourProjectName',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:7001',
    redirectUri: baseUrl,
    clientId: 'YourProjectName_App',
    responseType: 'code',
    scope: 'offline_access YourProjectName role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:7001',
      rootNamespace: 'YourCompany.YourProjectName',
    },
    YourProjectName: {
      url: 'https://localhost:7002',
      rootNamespace: 'YourCompany.YourProjectName',
    },
  },
} as Environment;
