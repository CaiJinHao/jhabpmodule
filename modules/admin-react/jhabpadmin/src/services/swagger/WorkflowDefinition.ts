// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/v${param0}/WorkflowDefinition */
export async function getV{apiVersion}WorkflowDefinition(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/WorkflowDefinition`, {
  method: 'GET',
    params: {
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/WorkflowDefinition */
export async function postV{apiVersion}WorkflowDefinition(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.WorkflowDefinitionCreateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.WorkflowDefinitionDto>(`/api/v${param0}/WorkflowDefinition`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/WorkflowDefinition/${param0} */
export async function getV{apiVersion}WorkflowDefinitionById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.WorkflowDefinitionDto>(`/api/v${param1}/WorkflowDefinition/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/WorkflowDefinition/${param0} */
export async function putV{apiVersion}WorkflowDefinitionById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.WorkflowDefinitionUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.WorkflowDefinitionDto>(`/api/v${param1}/WorkflowDefinition/${param0}`, {
  method: 'PUT',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param1}/WorkflowDefinition/${param0} */
export async function deleteV{apiVersion}WorkflowDefinitionById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/WorkflowDefinition/${param0}`, {
  method: 'DELETE',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/WorkflowDefinition/${param0} */
export async function patchV{apiVersion}WorkflowDefinitionById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.WorkflowDefinitionUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/WorkflowDefinition/${param0}`, {
  method: 'PATCH',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 DELETE /api/v${param0}/WorkflowDefinition/keys */
export async function deleteV{apiVersion}WorkflowDefinitionKeys(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: string[],
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/WorkflowDefinition/keys`, {
  method: 'DELETE',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/WorkflowDefinition/Patch/${param0} */
export async function patchV{apiVersion}WorkflowDefinitionPatchById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.WorkflowDefinitionUpdateInputDto),
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/WorkflowDefinition/Patch/${param0}`, {
  method: 'PATCH',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PUT /api/v${param1}/WorkflowDefinition/${param0}/Recover */
export async function putV{apiVersion}WorkflowDefinitionByIdRecover(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/WorkflowDefinition/${param0}/Recover`, {
  method: 'PUT',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 PATCH /api/v${param1}/WorkflowDefinition/${param0}/Recover */
export async function patchV{apiVersion}WorkflowDefinitionByIdRecover(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'id': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param1}/WorkflowDefinition/${param0}/Recover`, {
  method: 'PATCH',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/WorkflowDefinition/all */
export async function getV{apiVersion}WorkflowDefinitionAll(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/WorkflowDefinition/all`, {
  method: 'GET',
    params: {
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/WorkflowDefinition/Steps */
export async function getV{apiVersion}WorkflowDefinitionSteps(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/WorkflowDefinition/Steps`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

