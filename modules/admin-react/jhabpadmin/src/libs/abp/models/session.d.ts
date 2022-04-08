export interface FindTenantResultDto {
  success: boolean;
  tenantId?: string;
  name?: string;
  isActive: boolean;
}
export interface CurrentTenantDto {
  id?: string;
  name?: string;
  isAvailable: boolean;
}
export interface MultiTenancyInfoDto {
  isEnabled: boolean;
}

export declare namespace Session {
  interface State {
    language: string;
    tenant: CurrentTenantDto;
  }
}
