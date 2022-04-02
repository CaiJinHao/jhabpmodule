// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/identity/users/lookup/${param0} */
export async function getIdentityUsersLookupById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 
  ...queryParams
  } = params;
  return request<API.UserData>(`/api/identity/users/lookup/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/users/lookup/by-username/${param0} */
export async function getIdentityUsersLookupByUsernameByUserName(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'userName': param0, 
  ...queryParams
  } = params;
  return request<API.UserData>(`/api/identity/users/lookup/by-username/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/users/lookup/search */
export async function getIdentityUsersLookupSearch(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  return request<API.0CultureneutralPublicKeyTokennull>('/api/identity/users/lookup/search', {
  method: 'GET',
    params: {
        
        
        
        ...params,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/identity/users/lookup/count */
export async function getIdentityUsersLookupCount(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  return request<number>('/api/identity/users/lookup/count', {
  method: 'GET',
    params: {
        ...params,},
    ...(options || {}),
  });
}

