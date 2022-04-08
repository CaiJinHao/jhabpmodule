
import type { CreationAuditedEntityDto, ExtensibleFullAuditedEntityDto, ExtensibleObject, PagedAndSortedResultRequestDto } from '@abp/ng.core';



export interface MenuCreateInputDto extends ExtensibleObject {
  menuCode: string;
  menuName: string;
  menuIcon: string;
  menuSort: number;
  menuParentCode?: string;
  menuUrl?: string;
  menuDescription?: string;
  menuPlatform: number;
  concurrencyStamp?: string;
  roleIds: string[];
}


export interface MenuDto extends ExtensibleFullAuditedEntityDto<string> {
  menuCode?: string;
  menuName?: string;
  menuIcon?: string;
  menuSort?: number;
  menuParentCode?: string;
  menuUrl?: string;
  menuDescription?: string;
  menuPlatform?: number;
  tenantId?: string;
  concurrencyStamp?: string;
}


export interface MenuRetrieveInputDto extends PagedAndSortedResultRequestDto {
  deleted?: number;
  menuCode?: string;
  menuName?: string;
  sort?: number;
  menuParentCode?: string;
  orMenuCode?: string;
}



export interface MenuRoleMapCreateInputDto {
  menuIds: string[];
  roleIds: string[];
}


export interface MenuRoleMapDto extends CreationAuditedEntityDto<string> {
  menuId?: string;
  roleId?: string;
  tenantId?: string;
}


export interface MenuRoleMapRetrieveInputDto extends PagedAndSortedResultRequestDto {
  tenantId?: string;
  menuId?: string;
  roleId?: string;
}


export interface MenuRoleMapUpdateInputDto {
  menuId?: string;
  roleId?: string;
  tenantId?: string;
}


export interface MenuUpdateInputDto extends ExtensibleObject {
  menuCode?: string;
  menuName?: string;
  menuIcon?: string;
  menuSort?: number;
  menuParentCode?: string;
  menuUrl?: string;
  menuDescription?: string;
  menuPlatform?: number;
  concurrencyStamp?: string;
  isDeleted: boolean;
}

