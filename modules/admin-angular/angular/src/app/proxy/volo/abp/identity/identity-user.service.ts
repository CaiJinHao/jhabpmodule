
  import type { GetIdentityUsersInput, IdentityRoleDto, IdentityUserCreateDto, IdentityUserDto, IdentityUserUpdateDto, IdentityUserUpdateRolesDto } from './models';

  

  import type { ListResultDto, PagedResultDto } from '@abp/ng.core';

  

import { request } from 'umi';

export const  createIdentityUser = async (input: IdentityUserCreateDto):Promise<IdentityUserDto> => {
    return await request<IdentityUserDto>('/api/identity/users',{
      method: 'POST',
      data: input,
    });
  }

export const  deleteIdentityUser = async (id: string):Promise<void> => {
    return await request<void>(`/api/identity/users/${id}`,{
      method: 'DELETE',
    });
  }

export const  findByEmailIdentityUser = async (email: string):Promise<IdentityUserDto> => {
    return await request<IdentityUserDto>(`/api/identity/users/by-email/${email}`,{
      method: 'GET',
    });
  }

export const  findByUsernameIdentityUser = async (userName: string):Promise<IdentityUserDto> => {
    return await request<IdentityUserDto>(`/api/identity/users/by-username/${userName}`,{
      method: 'GET',
    });
  }

export const  getIdentityUser = async (id: string):Promise<IdentityUserDto> => {
    return await request<IdentityUserDto>(`/api/identity/users/${id}`,{
      method: 'GET',
    });
  }

export const  getAssignableRolesIdentityUser = async ():Promise<ListResultDto<IdentityRoleDto>> => {
    return await request<ListResultDto<IdentityRoleDto>>('/api/identity/users/assignable-roles',{
      method: 'GET',
    });
  }

export const  getListIdentityUser = async (input: GetIdentityUsersInput):Promise<PagedResultDto<IdentityUserDto>> => {
    return await request<PagedResultDto<IdentityUserDto>>('/api/identity/users',{
      method: 'GET',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    });
  }

export const  getRolesIdentityUser = async (id: string):Promise<ListResultDto<IdentityRoleDto>> => {
    return await request<ListResultDto<IdentityRoleDto>>(`/api/identity/users/${id}/roles`,{
      method: 'GET',
    });
  }

export const  updateIdentityUser = async (id: string, input: IdentityUserUpdateDto):Promise<IdentityUserDto> => {
    return await request<IdentityUserDto>(`/api/identity/users/${id}`,{
      method: 'PUT',
      data: input,
    });
  }

export const  updateRolesIdentityUser = async (id: string, input: IdentityUserUpdateRolesDto):Promise<void> => {
    return await request<void>(`/api/identity/users/${id}/roles`,{
      method: 'PUT',
      data: input,
    });
  }

