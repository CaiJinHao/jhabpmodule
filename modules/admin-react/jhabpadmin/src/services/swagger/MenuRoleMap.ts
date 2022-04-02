// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 POST /api/v${param0}/MenuRoleMap */
export async function postV{apiVersion}MenuRoleMap(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.MenuRoleMapCreateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.MenuRoleMapDto>(`/api/v${param0}/MenuRoleMap`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/MenuRoleMap/Trees */
export async function getV{apiVersion}MenuRoleMapTrees(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.TreeDto[]>(`/api/v${param0}/MenuRoleMap/Trees`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/MenuRoleMap/TreesAll */
export async function getV{apiVersion}MenuRoleMapTreesAll(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.TreeDto[]>(`/api/v${param0}/MenuRoleMap/TreesAll`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

