// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/v${param0}/IdentityRole */
export async function getV{apiVersion}IdentityRole(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/IdentityRole`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/IdentityRole */
export async function postV{apiVersion}IdentityRole(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityRoleCreateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityRoleDto>(`/api/v${param0}/IdentityRole`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/IdentityRole/roles */
export async function postV{apiVersion}IdentityRoleRoles(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityRoleCreateDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityRoleDto>(`/api/v${param0}/IdentityRole/roles`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/IdentityRole/${param0} */
export async function getV{apiVersion}IdentityRoleById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.IdentityRoleDto>(`/api/v${param1}/IdentityRole/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/IdentityRole/${param0} */
export async function putV{apiVersion}IdentityRoleById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityRoleUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.IdentityRoleDto>(`/api/v${param1}/IdentityRole/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param1}/IdentityRole/${param0} */
export async function deleteV{apiVersion}IdentityRoleById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/IdentityRole/${param0}`, {
  method: 'DELETE',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/IdentityRole/${param0} */
export async function patchV{apiVersion}IdentityRoleById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityRoleUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/IdentityRole/${param0}`, {
  method: 'PATCH',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param0}/IdentityRole/keys */
export async function deleteV{apiVersion}IdentityRoleKeys(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: string[],
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/IdentityRole/keys`, {
  method: 'DELETE',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/IdentityRole/all */
export async function getV{apiVersion}IdentityRoleAll(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/IdentityRole/all`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/IdentityRole/tree */
export async function getV{apiVersion}IdentityRoleTree(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/IdentityRole/tree`, {
  method: 'GET',
    params: {
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/IdentityRole/select */
export async function getV{apiVersion}IdentityRoleSelect(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/IdentityRole/select`, {
  method: 'GET',
    params: {
        ...queryParams,},
    ...(options || {}),
  });
}

