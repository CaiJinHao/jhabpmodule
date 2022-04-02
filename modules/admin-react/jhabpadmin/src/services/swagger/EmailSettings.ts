// @ts-ignore
/* eslint-disable */
import { request } from 'umi';

/** 此处后端没有提供注释 GET /api/setting-management/emailing */
export async function getSettingManagementEmailing(options?: { [key: string]: any }) {
  return request<API.EmailSettingsDto>('/api/setting-management/emailing', {
    method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/setting-management/emailing */
export async function postSettingManagementEmailing(
  body: API.UpdateEmailSettingsDto,
  options?: { [key: string]: any },
) {
  return request<any>('/api/setting-management/emailing', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    data: body,
    ...(options || {}),
  });
}
