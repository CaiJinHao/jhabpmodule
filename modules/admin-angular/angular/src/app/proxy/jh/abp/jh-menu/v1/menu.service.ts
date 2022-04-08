
  

  import type { ListResultDto, PagedResultDto } from '@abp/ng.core';

  

  import type { MenuCreateInputDto, MenuDto, MenuRetrieveInputDto, MenuUpdateInputDto } from '../models';

import { request } from 'umi';




export const  createMenu = async (
   input: any 
  ) => {

    return await request(`/api/v${apiVersion}/Menu`,{
      method: 'POST',
      data: input,
    });
  }



export const  deleteMenuBykeys = async (keys: string[]) => {

    return await request(`/api/v${apiVersion}/Menu/keys`,{
      method: 'DELETE',
      data: keys,
    });
  }



export const  deleteMenuByid = async (id: string) => {

    return await request(`/api/v${apiVersion}/Menu/${id}`,{
      method: 'DELETE',
    });
  }



export const  getMenu = async (
   id: any 
  ) => {

    return await request(`/api/v${apiVersion}/Menu/${id}`,{
      method: 'GET',
    });
  }



export const  getEntitysMenu = async (
   inputDto: any 
  ) => {

    return await request(`/api/v${inputDto}/Menu/all`,{
      method: 'GET',
      params: { deleted: inputDto.deleted, methodInput_StringTypeQueryMethod: inputDto.methodInput_StringTypeQueryMethod, menuCode: inputDto.menuCode, menuName: inputDto.menuName, sort: inputDto.sort, menuParentCode: inputDto.menuParentCode, orMenuCode: inputDto.orMenuCode, sorting: inputDto.sorting, skipCount: inputDto.skipCount, maxResultCount: inputDto.maxResultCount },
    });
  }



export const  getListMenu = async (
   input: any 
  ) => {

    return await request(`/api/v${input}/Menu`,{
      method: 'GET',
      params: { deleted: input.deleted, methodInput_StringTypeQueryMethod: input.methodInput_StringTypeQueryMethod, menuCode: input.menuCode, menuName: input.menuName, sort: input.sort, menuParentCode: input.menuParentCode, orMenuCode: input.orMenuCode, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    });
  }



export const  getMaxMenuCodeMenu = async (
   parentCode: any 
  ) => {

    return await request(`/api/v${apiVersion}/Menu/MaxCode/${parentCode}`,{
      method: 'GET',
      responseType: 'text',
    });
  }



export const  recoverMenu = async (
   id: any 
  ) => {

    return await request(`/api/v${apiVersion}/Menu/${id}/Recover`,{
      method: 'PATCH',
    });
  }



export const  updateMenu = async (
   id: any 
  ) => {

    return await request(`/api/v${apiVersion}/Menu/${id}`,{
      method: 'PUT',
      data: input,
    });
  }



export const  updatePortionMenu = async (
   id: any 
  ) => {

    return await request(`/api/v${apiVersion}/Menu/Patch/${id}`,{
      method: 'PUT',
      data: inputDto,
    });
  }


