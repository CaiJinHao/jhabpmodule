// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 POST /api/v${param0}/AccessToken */
export async function postV{apiVersion}AccessToken(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.AccessTokenRequestDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.AccessTokenResponseDto>(`/api/v${param0}/AccessToken`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/AccessToken/Refresh */
export async function postV{apiVersion}AccessTokenRefresh(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.AccessTokenRefreshDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.AccessTokenResponseDto>(`/api/v${param0}/AccessToken/Refresh`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/AccessToken/Token */
export async function postV{apiVersion}AccessTokenToken(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.AccessTokenResponseDto>(`/api/v${param0}/AccessToken/Token`, {
  method: 'POST',
    params: {
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/AccessToken/claims */
export async function getV{apiVersion}AccessTokenClaims(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/AccessToken/claims`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

