// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 POST /api/v${param0}/JhPermissions/PermissionGranted */
export async function postV{apiVersion}JhPermissionsPermissionGranted(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.PermissionGrantedRetrieveInputDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.PermissionGrantedDto[]>(`/api/v${param0}/JhPermissions/PermissionGranted`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/JhPermissions/InterfaceTreesAll */
export async function getV{apiVersion}JhPermissionsInterfaceTreesAll(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/JhPermissions/InterfaceTreesAll`, {
  method: 'GET',
    params: {
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/JhPermissions/Interface */
export async function postV{apiVersion}JhPermissionsInterface(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.PermissionGrantedCreateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/JhPermissions/Interface`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/JhPermissions */
export async function getV{apiVersion}JhPermissions(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.GetPermissionListResultDto>(`/api/v${param0}/JhPermissions`, {
  method: 'GET',
    params: {
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param0}/JhPermissions */
export async function putV{apiVersion}JhPermissions(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.UpdatePermissionsDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/JhPermissions`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {
        
        ...queryParams,},
    data: body,
    ...(options || {}),
  });
}

