
  import type { SampleDto } from './models';

  

  

import { request } from 'umi';




export const  getSample = async (
  
  ) => {

    return await request('/api/JhMenu/sample',{
      method: 'GET',
    });
  }



export const  getAllClaimsSample = async (
  
  ) => {

    return await request('/api/JhMenu/sample/Claims',{
      method: 'GET',
    });
  }



export const  getAuthorizedSample = async (
  
  ) => {

    return await request('/api/JhMenu/sample/authorized',{
      method: 'GET',
    });
  }


