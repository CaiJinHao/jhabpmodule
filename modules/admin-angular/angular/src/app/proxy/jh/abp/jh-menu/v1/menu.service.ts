
  

  import type { ListResultDto, PagedResultDto } from '@abp/ng.core';

  

  import type { MenuCreateInputDto, MenuDto, MenuRetrieveInputDto, MenuUpdateInputDto } from '../models';

import { request } from 'umi';





export const  createMenu = async (input: MenuCreateInputDto): Promise<MenuDto> => {

    return await request<MenuDto>('/api/v1/Menu',{
      method: 'POST',
      data: input,
    });
  }




export const  deleteMenuBykeys = async (keys: string[]):Promise<void> => {

    return await request<void>('/api/v1/Menu/keys',{
      method: 'DELETE',
      data: keys,
    });
  }




export const  deleteMenuByid = async (id: string):Promise<void> => {

    return await request<void>(`/api/v1/Menu/${id}`,{
      method: 'DELETE',
    });
  }




export const  getMenu = async (id: string): Promise<MenuDto> => {

    return await request<MenuDto>(`/api/v1/Menu/${id}`,{
      method: 'GET',
    });
  }




export const  getEntitysMenu = async (inputDto: MenuRetrieveInputDto): Promise<ListResultDto<MenuDto>> => {

    return await request<ListResultDto<MenuDto>>('/api/v1/Menu/all',{
      method: 'GET',
      params: { deleted: inputDto.deleted, methodInput_StringTypeQueryMethod: inputDto.methodInput_StringTypeQueryMethod, menuCode: inputDto.menuCode, menuName: inputDto.menuName, sort: inputDto.sort, menuParentCode: inputDto.menuParentCode, orMenuCode: inputDto.orMenuCode, sorting: inputDto.sorting, skipCount: inputDto.skipCount, maxResultCount: inputDto.maxResultCount },
    });
  }




export const  getListMenu = async (input: MenuRetrieveInputDto): Promise<PagedResultDto<MenuDto>> => {

    return await request<PagedResultDto<MenuDto>>('/api/v1/Menu',{
      method: 'GET',
      params: { deleted: input.deleted, methodInput_StringTypeQueryMethod: input.methodInput_StringTypeQueryMethod, menuCode: input.menuCode, menuName: input.menuName, sort: input.sort, menuParentCode: input.menuParentCode, orMenuCode: input.orMenuCode, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    });
  }




export const  getMaxMenuCodeMenu = async (parentCode: string): Promise<string> => {

    return await request<string>(`/api/v1/Menu/MaxCode/${parentCode}`,{
      method: 'GET',
      responseType: 'text',
    });
  }




export const  recoverMenu = async (id: string): Promise<void> => {

    return await request<void>(`/api/v1/Menu/${id}/Recover`,{
      method: 'PATCH',
    });
  }




export const  updateMenu = async (id: string, input: MenuUpdateInputDto): Promise<MenuDto> => {

    return await request<MenuDto>(`/api/v1/Menu/${id}`,{
      method: 'PUT',
      data: input,
    });
  }




export const  updatePortionMenu = async (id: string, inputDto: MenuUpdateInputDto): Promise<void> => {

    return await request<void>(`/api/v1/Menu/Patch/${id}`,{
      method: 'PUT',
      data: inputDto,
    });
  }


