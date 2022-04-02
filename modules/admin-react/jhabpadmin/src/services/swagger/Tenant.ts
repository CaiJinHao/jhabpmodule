// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/multi-tenancy/tenants/${param0} */
export async function getMultiTenancyTenantsById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<API.TenantDto>(`/api/multi-tenancy/tenants/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/multi-tenancy/tenants/${param0} */
export async function putMultiTenancyTenantsById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.TenantUpdateDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<API.TenantDto>(`/api/multi-tenancy/tenants/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/multi-tenancy/tenants/${param0} */
export async function deleteMultiTenancyTenantsById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/multi-tenancy/tenants/${param0}`, {
  method: 'DELETE',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/multi-tenancy/tenants */
export async function getMultiTenancyTenants(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  return request<API.0CultureneutralPublicKeyTokennull>('/api/multi-tenancy/tenants', {
  method: 'GET',
    params: {
        
        
        
        ...params,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/multi-tenancy/tenants */
export async function postMultiTenancyTenants(body: (API.TenantCreateDto),
  options ?: {[key: string]: any}
) {
  return request<API.TenantDto>('/api/multi-tenancy/tenants', {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/multi-tenancy/tenants/${param0}/default-connection-string */
export async function getMultiTenancyTenantsByIdDefaultConnectionString(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<string>(`/api/multi-tenancy/tenants/${param0}/default-connection-string`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/multi-tenancy/tenants/${param0}/default-connection-string */
export async function putMultiTenancyTenantsByIdDefaultConnectionString(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/multi-tenancy/tenants/${param0}/default-connection-string`, {
  method: 'PUT',
    params: {
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/multi-tenancy/tenants/${param0}/default-connection-string */
export async function deleteMultiTenancyTenantsByIdDefaultConnectionString(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/multi-tenancy/tenants/${param0}/default-connection-string`, {
  method: 'DELETE',
    params: {...queryParams,},
    ...(options || {}),
  });
}

