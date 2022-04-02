// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/identity/roles/all */
export async function getIdentityRolesAll(
  options ?: {[key: string]: any}
) {
  return request<API.0CultureneutralPublicKeyTokennull>('/api/identity/roles/all', {
  method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/roles */
export async function getIdentityRoles(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  return request<API.0CultureneutralPublicKeyTokennull>('/api/identity/roles', {
  method: 'GET',
    params: {
        
        
        
        ...params,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/identity/roles */
export async function postIdentityRoles(body: (API.IdentityRoleCreateDto),
  options ?: {[key: string]: any}
) {
  return request<API.IdentityRoleDto>('/api/identity/roles', {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/roles/${param0} */
export async function getIdentityRolesById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityRoleDto>(`/api/identity/roles/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/identity/roles/${param0} */
export async function putIdentityRolesById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityRoleUpdateDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityRoleDto>(`/api/identity/roles/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/identity/roles/${param0} */
export async function deleteIdentityRolesById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/identity/roles/${param0}`, {
  method: 'DELETE',
    params: {...queryParams,},
    ...(options || {}),
  });
}

