
  import type { ChangePasswordInput, ProfileDto, UpdateProfileDto } from './models';

  

  

import { request } from 'umi';




export const  changePasswordProfile = async (
   input: any 
  ) => {

    return await request('/api/account/my-profile/change-password',{
      method: 'POST',
      data: input,
    });
  }



export const  getProfile = async (
  
  ) => {

    return await request('/api/account/my-profile',{
      method: 'GET',
    });
  }



export const  updateProfile = async (
   input: any 
  ) => {

    return await request('/api/account/my-profile',{
      method: 'PUT',
      data: input,
    });
  }


