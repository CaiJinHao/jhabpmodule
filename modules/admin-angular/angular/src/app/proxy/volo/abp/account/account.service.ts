
  import type { RegisterDto, ResetPasswordDto, SendPasswordResetCodeDto } from './models';

  

  

  import type { IdentityUserDto } from '../identity/models';

import { request } from 'umi';




export const  registerAccount = async (
   input: any 
  ) => {

    return await request('/api/account/register',{
      method: 'POST',
      data: input,
    });
  }



export const  resetPasswordAccount = async (
   input: any 
  ) => {

    return await request('/api/account/reset-password',{
      method: 'POST',
      data: input,
    });
  }



export const  sendPasswordResetCodeAccount = async (
   input: any 
  ) => {

    return await request('/api/account/send-password-reset-code',{
      method: 'POST',
      data: input,
    });
  }


