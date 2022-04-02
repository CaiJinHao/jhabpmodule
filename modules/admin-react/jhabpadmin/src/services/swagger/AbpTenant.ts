// @ts-ignore
/* eslint-disable */
import { request } from 'umi';

/** 此处后端没有提供注释 GET /api/abp/multi-tenancy/tenants/by-name/${param0} */
export async function getAbpMultiTenancyTenantsByNameByName(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams,
  options?: { [key: string]: any },
) {
  const { name: param0, ...queryParams } = params;
  return request<API.FindTenantResultDto>(`/api/abp/multi-tenancy/tenants/by-name/${param0}`, {
    method: 'GET',
    params: { ...queryParams },
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 GET /api/abp/multi-tenancy/tenants/by-id/${param0} */
export async function getAbpMultiTenancyTenantsByIdById(
  // 叠加生成的Param类型 (非body参数swagger默认没有生成对象)
  params: API.undefinedParams,
  options?: { [key: string]: any },
) {
  const { id: param0, ...queryParams } = params;
  return request<API.FindTenantResultDto>(`/api/abp/multi-tenancy/tenants/by-id/${param0}`, {
    method: 'GET',
    params: { ...queryParams },
    ...(options || {}),
  });
}
