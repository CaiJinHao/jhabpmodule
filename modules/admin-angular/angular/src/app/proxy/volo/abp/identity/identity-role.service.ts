
  import type { GetIdentityRolesInput, IdentityRoleCreateDto, IdentityRoleDto, IdentityRoleUpdateDto } from './models';

  

  import type { ListResultDto, PagedResultDto } from '@abp/ng.core';

  

import { request } from 'umi';

export const  createIdentityRole = async (input: IdentityRoleCreateDto):Promise<IdentityRoleDto> => {
    return await request<IdentityRoleDto>('/api/identity/roles',{
      method: 'POST',
      data: input,
    });
  }

export const  deleteIdentityRole = async (id: string):Promise<void> => {
    return await request<void>(`/api/identity/roles/${id}`,{
      method: 'DELETE',
    });
  }

export const  getIdentityRole = async (id: string):Promise<IdentityRoleDto> => {
    return await request<IdentityRoleDto>(`/api/identity/roles/${id}`,{
      method: 'GET',
    });
  }

export const  getAllListIdentityRole = async ():Promise<ListResultDto<IdentityRoleDto>> => {
    return await request<ListResultDto<IdentityRoleDto>>('/api/identity/roles/all',{
      method: 'GET',
    });
  }

export const  getListIdentityRole = async (input: GetIdentityRolesInput):Promise<PagedResultDto<IdentityRoleDto>> => {
    return await request<PagedResultDto<IdentityRoleDto>>('/api/identity/roles',{
      method: 'GET',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    });
  }

export const  updateIdentityRole = async (id: string, input: IdentityRoleUpdateDto):Promise<IdentityRoleDto> => {
    return await request<IdentityRoleDto>(`/api/identity/roles/${id}`,{
      method: 'PUT',
      data: input,
    });
  }

