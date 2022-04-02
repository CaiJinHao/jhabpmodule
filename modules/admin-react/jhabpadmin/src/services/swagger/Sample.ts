// @ts-ignore
/* eslint-disable */
import { request } from 'umi';

/** 此处后端没有提供注释 GET /api/JhIdentity/sample */
export async function getJhIdentitySample(options?: { [key: string]: any }) {
  return request<API.SampleDto>('/api/JhIdentity/sample', {
    method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/JhIdentity/sample/authorized */
export async function getJhIdentitySampleAuthorized(options?: { [key: string]: any }) {
  return request<API.SampleDto>('/api/JhIdentity/sample/authorized', {
    method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/JhIdentity/sample/Claims */
export async function getJhIdentitySampleClaims(options?: { [key: string]: any }) {
  return request<any>('/api/JhIdentity/sample/Claims', {
    method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/JhMenu/sample */
export async function getJhMenuSample(options?: { [key: string]: any }) {
  return request<API.SampleDto>('/api/JhMenu/sample', {
    method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/JhMenu/sample/authorized */
export async function getJhMenuSampleAuthorized(options?: { [key: string]: any }) {
  return request<API.SampleDto>('/api/JhMenu/sample/authorized', {
    method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/JhMenu/sample/Claims */
export async function getJhMenuSampleClaims(options?: { [key: string]: any }) {
  return request<any>('/api/JhMenu/sample/Claims', {
    method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/Workflow/sample */
export async function getWorkflowSample(options?: { [key: string]: any }) {
  return request<API.SampleDto>('/api/Workflow/sample', {
    method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/Workflow/sample/Claims */
export async function getWorkflowSampleClaims(options?: { [key: string]: any }) {
  return request<any>('/api/Workflow/sample/Claims', {
    method: 'GET',
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/Workflow/sample/authorized */
export async function getWorkflowSampleAuthorized(options?: { [key: string]: any }) {
  return request<API.SampleDto>('/api/Workflow/sample/authorized', {
    method: 'GET',
    ...(options || {}),
  });
}
