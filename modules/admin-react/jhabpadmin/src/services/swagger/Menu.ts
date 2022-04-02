// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/v${param0}/Menu */
export async function getV{apiVersion}Menu(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/Menu`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/Menu */
export async function postV{apiVersion}Menu(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.MenuCreateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.MenuDto>(`/api/v${param0}/Menu`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/Menu/${param0} */
export async function getV{apiVersion}MenuById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.MenuDto>(`/api/v${param1}/Menu/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/Menu/${param0} */
export async function putV{apiVersion}MenuById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.MenuUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.MenuDto>(`/api/v${param1}/Menu/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param1}/Menu/${param0} */
export async function deleteV{apiVersion}MenuById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/Menu/${param0}`, {
  method: 'DELETE',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/Menu/${param0} */
export async function patchV{apiVersion}MenuById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.MenuUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/Menu/${param0}`, {
  method: 'PATCH',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param0}/Menu/keys */
export async function deleteV{apiVersion}MenuKeys(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: string[],
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/Menu/keys`, {
  method: 'DELETE',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/Menu/Patch/${param0} */
export async function putV{apiVersion}MenuPatchById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.MenuUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/Menu/Patch/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/Menu/${param0}/Recover */
export async function putV{apiVersion}MenuByIdRecover(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/Menu/${param0}/Recover`, {
  method: 'PUT',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/Menu/${param0}/Recover */
export async function patchV{apiVersion}MenuByIdRecover(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/Menu/${param0}/Recover`, {
  method: 'PATCH',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/Menu/all */
export async function getV{apiVersion}MenuAll(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/Menu/all`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/Menu/MaxCode/${param0} */
export async function getV{apiVersion}MenuMaxCodeByParentCode(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'parentCode': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<string>(`/api/v${param1}/Menu/MaxCode/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

