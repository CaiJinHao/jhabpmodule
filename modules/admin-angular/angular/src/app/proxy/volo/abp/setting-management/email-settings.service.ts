
  import type { EmailSettingsDto, UpdateEmailSettingsDto } from './models';

  

  

import { request } from 'umi';




export const  getEmailSettings = async (): Promise<EmailSettingsDto> => {

    return await request<EmailSettingsDto>('/api/setting-management/emailing',{
      method: 'GET',
    });
  }




export const  updateEmailSettings = async (input: UpdateEmailSettingsDto): Promise<void> => {

    return await request<void>('/api/setting-management/emailing',{
      method: 'POST',
      data: input,
    });
  }


