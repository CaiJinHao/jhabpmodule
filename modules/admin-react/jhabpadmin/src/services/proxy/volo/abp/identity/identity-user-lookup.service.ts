import type { UserLookupCountInputDto, UserLookupSearchInputDto } from './models';

import type { ListResultDto } from '@/libs/abp/models';

import type { UserData } from '../users/models';

import { request } from 'umi';

export const findByIdIdentityUserLookup = async (id: string): Promise<UserData> => {
  return await request<UserData>(`/api/identity/users/lookup/${id}`, {
    method: 'GET',
  });
};

export const findByUserNameIdentityUserLookup = async (userName: string): Promise<UserData> => {
  return await request<UserData>(`/api/identity/users/lookup/by-username/${userName}`, {
    method: 'GET',
  });
};

export const getCountIdentityUserLookup = async (
  input: UserLookupCountInputDto,
): Promise<number> => {
  return await request<number>('/api/identity/users/lookup/count', {
    method: 'GET',
    params: { filter: input.filter },
  });
};

export const searchIdentityUserLookup = async (
  input: UserLookupSearchInputDto,
): Promise<ListResultDto<UserData>> => {
  return await request<ListResultDto<UserData>>('/api/identity/users/lookup/search', {
    method: 'GET',
    params: {
      filter: input.filter,
      sorting: input.sorting,
      skipCount: input.skipCount,
      maxResultCount: input.maxResultCount,
    },
  });
};
