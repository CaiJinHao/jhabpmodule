// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/v${param0}/OrganizationUnit */
export async function getV{apiVersion}OrganizationUnit(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/OrganizationUnit`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/OrganizationUnit */
export async function postV{apiVersion}OrganizationUnit(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.OrganizationUnitCreateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.OrganizationUnitDto>(`/api/v${param0}/OrganizationUnit`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/OrganizationUnit/${param0} */
export async function getV{apiVersion}OrganizationUnitById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.OrganizationUnitDto>(`/api/v${param1}/OrganizationUnit/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/OrganizationUnit/${param0} */
export async function putV{apiVersion}OrganizationUnitById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.OrganizationUnitUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.OrganizationUnitDto>(`/api/v${param1}/OrganizationUnit/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param1}/OrganizationUnit/${param0} */
export async function deleteV{apiVersion}OrganizationUnitById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/OrganizationUnit/${param0}`, {
  method: 'DELETE',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/OrganizationUnit/${param0} */
export async function patchV{apiVersion}OrganizationUnitById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.OrganizationUnitUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/OrganizationUnit/${param0}`, {
  method: 'PATCH',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param0}/OrganizationUnit/keys */
export async function deleteV{apiVersion}OrganizationUnitKeys(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: string[],
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/OrganizationUnit/keys`, {
  method: 'DELETE',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/OrganizationUnit/Patch/${param0} */
export async function putV{apiVersion}OrganizationUnitPatchById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.OrganizationUnitUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/OrganizationUnit/Patch/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/OrganizationUnit/${param0}/Recover */
export async function putV{apiVersion}OrganizationUnitByIdRecover(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/OrganizationUnit/${param0}/Recover`, {
  method: 'PUT',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/OrganizationUnit/${param0}/Recover */
export async function patchV{apiVersion}OrganizationUnitByIdRecover(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/OrganizationUnit/${param0}/Recover`, {
  method: 'PATCH',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/OrganizationUnit/all */
export async function getV{apiVersion}OrganizationUnitAll(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/OrganizationUnit/all`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/OrganizationUnit/${param0}/roles */
export async function getV{apiVersion}OrganizationUnitByIdRoles(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param1}/OrganizationUnit/${param0}/roles`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/OrganizationUnit/Trees */
export async function getV{apiVersion}OrganizationUnitTrees(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/OrganizationUnit/Trees`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/OrganizationUnit/select */
export async function getV{apiVersion}OrganizationUnitSelect(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/OrganizationUnit/select`, {
  method: 'GET',
    params: {
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/OrganizationUnit/${param0}/Members */
export async function getV{apiVersion}OrganizationUnitByIdMembers(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param1}/OrganizationUnit/${param0}/Members`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/OrganizationUnit/Role/${param0} */
export async function getV{apiVersion}OrganizationUnitRoleByRoleId(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'roleId': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/OrganizationUnit/Role/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

