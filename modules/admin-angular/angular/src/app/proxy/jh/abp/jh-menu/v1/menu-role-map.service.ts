
  

  import type { ListResultDto, PagedResultDto } from '@abp/ng.core';

  

  import type { TreeDto } from '../../common/models';

  import type { MenuRoleMapCreateInputDto, MenuRoleMapDto, MenuRoleMapRetrieveInputDto, MenuRoleMapUpdateInputDto } from '../models';

import { request } from 'umi';





export const  createMenuRoleMap = async (input: MenuRoleMapCreateInputDto): Promise<MenuRoleMapDto> => {

    return await request<MenuRoleMapDto>('/api/v1/MenuRoleMap',{
      method: 'POST',
      data: input,
    });
  }




export const  deleteMenuRoleMapByid = async (id: string):Promise<void> => {

    return await request<void>(`/api/v${apiVersion}/MenuRoleMap/${id}`,{
      method: 'DELETE',
    });
  }




export const  deleteMenuRoleMapBykeys = async (keys: string[]):Promise<void> => {

    return await request<void>(`/api/v${apiVersion}/MenuRoleMap/keys`,{
      method: 'DELETE',
      params: { keys },
    });
  }




export const  getMenuRoleMap = async (id: string): Promise<MenuRoleMapDto> => {

    return await request<MenuRoleMapDto>(`/api/v${apiVersion}/MenuRoleMap/${id}`,{
      method: 'GET',
    });
  }




export const  getEntitysMenuRoleMap = async (inputDto: MenuRoleMapRetrieveInputDto): Promise<ListResultDto<MenuRoleMapDto>> => {

    return await request<ListResultDto<MenuRoleMapDto>>(`/api/v${inputDto}/MenuRoleMap/all`,{
      method: 'GET',
      params: { methodInput_StringTypeQueryMethod: inputDto.methodInput_StringTypeQueryMethod, tenantId: inputDto.tenantId, menuId: inputDto.menuId, roleId: inputDto.roleId, sorting: inputDto.sorting, skipCount: inputDto.skipCount, maxResultCount: inputDto.maxResultCount },
    });
  }




export const  getListMenuRoleMap = async (input: MenuRoleMapRetrieveInputDto): Promise<PagedResultDto<MenuRoleMapDto>> => {

    return await request<PagedResultDto<MenuRoleMapDto>>(`/api/v${input}/MenuRoleMap`,{
      method: 'GET',
      params: { methodInput_StringTypeQueryMethod: input.methodInput_StringTypeQueryMethod, tenantId: input.tenantId, menuId: input.menuId, roleId: input.roleId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    });
  }




export const  getMenusNavTreesMenuRoleMap = async (): Promise<TreeDto[]> => {

    return await request<TreeDto[]>('/api/v1/MenuRoleMap/Trees',{
      method: 'GET',
    });
  }




export const  getMenusTreesMenuRoleMap = async (input: MenuRoleMapRetrieveInputDto): Promise<TreeDto[]> => {

    return await request<TreeDto[]>('/api/v1/MenuRoleMap/TreesAll',{
      method: 'GET',
      params: { methodInput_StringTypeQueryMethod: input.methodInput_StringTypeQueryMethod, tenantId: input.tenantId, menuId: input.menuId, roleId: input.roleId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    });
  }




export const  updateMenuRoleMap = async (id: string, input: MenuRoleMapUpdateInputDto): Promise<MenuRoleMapDto> => {

    return await request<MenuRoleMapDto>(`/api/v${apiVersion}/MenuRoleMap/${id}`,{
      method: 'PUT',
      data: input,
    });
  }




export const  updatePortionMenuRoleMap = async (id: string, inputDto: MenuRoleMapUpdateInputDto): Promise<void> => {

    return await request<void>(`/api/v${apiVersion}/MenuRoleMap/Patch/${id}`,{
      method: 'PUT',
      data: inputDto,
    });
  }


