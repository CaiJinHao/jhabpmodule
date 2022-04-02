// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/v${param0}/AppEnums/Use */
export async function getV{apiVersion}AppEnumsUse(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any[]>(`/api/v${param0}/AppEnums/Use`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/AppEnums/Delete */
export async function getV{apiVersion}AppEnumsDelete(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any[]>(`/api/v${param0}/AppEnums/Delete`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

