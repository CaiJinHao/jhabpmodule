
  import type { AbpLoginResult, UserLoginInfo } from './models/models';

  

  

import { request } from 'umi';




export const  checkPasswordByLoginAccount = async (
   login: any 
  ) => {

    return await request('/api/account/check-password',{
      method: 'POST',
      data: login,
    });
  }



export const  loginByLoginAccount = async (
   login: any 
  ) => {

    return await request('/api/account/login',{
      method: 'POST',
      data: login,
    });
  }



export const  logoutAccount = async (
  
  ) => {

    return await request('/api/account/logout',{
      method: 'GET',
    });
  }


