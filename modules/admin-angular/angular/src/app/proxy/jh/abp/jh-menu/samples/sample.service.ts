
  import type { SampleDto } from './models';

  

  

import { request } from 'umi';





export const  getSample = async (): Promise<SampleDto> => {

    return await request<SampleDto>('/api/JhMenu/sample',{
      method: 'GET',
    });
  }




export const  getAllClaimsSample = async (): Promise<object> => {

    return await request<object>('/api/JhMenu/sample/Claims',{
      method: 'GET',
    });
  }




export const  getAuthorizedSample = async (): Promise<SampleDto> => {

    return await request<SampleDto>('/api/JhMenu/sample/authorized',{
      method: 'GET',
    });
  }


