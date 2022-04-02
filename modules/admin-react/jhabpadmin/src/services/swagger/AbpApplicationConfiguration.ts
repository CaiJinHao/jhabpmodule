// @ts-ignore
/* eslint-disable */
import { request } from 'umi';

/** 此处后端没有提供注释 GET /api/abp/application-configuration */
export async function getAbpApplicationConfiguration(options?: { [key: string]: any }) {
  return request<API.ApplicationConfigurationDto>('/api/abp/application-configuration', {
    method: 'GET',
    ...(options || {}),
  });
}
