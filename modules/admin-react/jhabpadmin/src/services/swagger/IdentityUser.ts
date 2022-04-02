// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/v${param0}/IdentityUser */
export async function getV{apiVersion}IdentityUser(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/IdentityUser`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/IdentityUser */
export async function postV{apiVersion}IdentityUser(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityUserCreateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityUserDto>(`/api/v${param0}/IdentityUser`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/IdentityUser/${param0} */
export async function getV{apiVersion}IdentityUserById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.IdentityUserDto>(`/api/v${param1}/IdentityUser/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/IdentityUser/${param0} */
export async function putV{apiVersion}IdentityUserById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityUserUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.IdentityUserDto>(`/api/v${param1}/IdentityUser/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param1}/IdentityUser/${param0} */
export async function deleteV{apiVersion}IdentityUserById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/IdentityUser/${param0}`, {
  method: 'DELETE',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/IdentityUser/${param0} */
export async function patchV{apiVersion}IdentityUserById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.IdentityUserUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/IdentityUser/${param0}`, {
  method: 'PATCH',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param0}/IdentityUser/keys */
export async function deleteV{apiVersion}IdentityUserKeys(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: string[],
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/IdentityUser/keys`, {
  method: 'DELETE',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/IdentityUser/${param0}/lockoutEnabled */
export async function patchV{apiVersion}IdentityUserByIdLockoutEnabled(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: boolean,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/IdentityUser/${param0}/lockoutEnabled`, {
  method: 'PATCH',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/IdentityUser/${param0}/Recover */
export async function putV{apiVersion}IdentityUserByIdRecover(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: boolean,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/IdentityUser/${param0}/Recover`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/IdentityUser/${param0}/Recover */
export async function patchV{apiVersion}IdentityUserByIdRecover(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: boolean,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/IdentityUser/${param0}/Recover`, {
  method: 'PATCH',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/IdentityUser/${param0}/roles */
export async function getV{apiVersion}IdentityUserByIdRoles(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param1}/IdentityUser/${param0}/roles`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/IdentityUser/all */
export async function getV{apiVersion}IdentityUserAll(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/IdentityUser/all`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/IdentityUser/info */
export async function getV{apiVersion}IdentityUserInfo(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.IdentityUserDto>(`/api/v${param0}/IdentityUser/info`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/IdentityUser/${param0}/organizationunits */
export async function getV{apiVersion}IdentityUserByIdOrganizationunits(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param1}/IdentityUser/${param0}/organizationunits`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/IdentityUser/options */
export async function getV{apiVersion}IdentityUserOptions(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/IdentityUser/options`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/IdentityUser/${param0}/SuperiorUser */
export async function getV{apiVersion}IdentityUserByUserIdSuperiorUser(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'userId': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.IdentityUserDto>(`/api/v${param1}/IdentityUser/${param0}/SuperiorUser`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/IdentityUser/change-password */
export async function postV{apiVersion}IdentityUserChangePassword(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.ChangePasswordInputDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/IdentityUser/change-password`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

