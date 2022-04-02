// @ts-ignore
/* eslint-disable */
import { request } from 'umi'

/** 此处后端没有提供注释 GET /api/v${param0}/WorkflowInstance */
export async function getV{apiVersion}WorkflowInstance(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/WorkflowInstance`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param0}/WorkflowInstance/all */
export async function getV{apiVersion}WorkflowInstanceAll(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<API.0CultureneutralPublicKeyTokennull>(`/api/v${param0}/WorkflowInstance/all`, {
  method: 'GET',
    params: {
        
        
        
        
        
        
        
        ...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/WorkflowInstance/StartWorkflow */
export async function postV{apiVersion}WorkflowInstanceStartWorkflow(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.WorkflowStartDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<string>(`/api/v${param0}/WorkflowInstance/StartWorkflow`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/v${param1}/WorkflowInstance/Detail/${param0} */
export async function getV{apiVersion}WorkflowInstanceDetailByWorkflowId(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,
  options ?: {[key: string]: any}
) {
  const { 'workflowId': param0, 'apiVersion': param1, 
  ...queryParams
  } = params;
  return request<API.WorkflowInstance>(`/api/v${param1}/WorkflowInstance/Detail/${param0}`, {
  method: 'GET',
    params: {...queryParams,},
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/v${param0}/WorkflowInstance/PublishEvent */
export async function postV{apiVersion}WorkflowInstancePublishEvent(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams
    ,body: (API.WorkflowPublishEventDto),
  options ?: {[key: string]: any}
) {
  const { 'apiVersion': param0, 
  ...queryParams
  } = params;
  return request<any>(`/api/v${param0}/WorkflowInstance/PublishEvent`, {
  method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    params: {...queryParams,},
    data: body,
    ...(options || {}),
  });
}

