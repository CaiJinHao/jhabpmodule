// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/identity/users/${param0} */
export async function getIdentityUsersById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityUserDto>(`/api/identity/users/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/identity/users/${param0} */
export async function putIdentityUsersById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityUserUpdateDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityUserDto>(`/api/identity/users/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/identity/users/${param0} */
export async function deleteIdentityUsersById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/identity/users/${param0}`, {
  method: 'DELETE',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/users */
export async function getIdentityUsers(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  return request<API.0CultureneutralPublicKeyTokennull>('/api/identity/users', {
  method: 'GET',
    params: {
        
        
        
        ...params,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/identity/users */
export async function postIdentityUsers(body: (API.IdentityUserCreateDto),
  options ?: {[key: string]: any}
) {
  return request<API.IdentityUserDto>('/api/identity/users', {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/users/${param0}/roles */
export async function getIdentityUsersByIdRoles(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/identity/users/${param0}/roles`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/identity/users/${param0}/roles */
export async function putIdentityUsersByIdRoles(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityUserUpdateRolesDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/identity/users/${param0}/roles`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/users/assignable-roles */
export async function getIdentityUsersAssignableRoles(
  options ?: {[key: string]: any}
) {
  return request<API.0CultureneutralPublicKeyTokennull>('/api/identity/users/assignable-roles', {
  method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/users/by-username/${param0} */
export async function getIdentityUsersByUsernameByUserName(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'userName': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityUserDto>(`/api/identity/users/by-username/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/users/by-email/${param0} */
export async function getIdentityUsersByEmailByEmail(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'email': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityUserDto>(`/api/identity/users/by-email/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

