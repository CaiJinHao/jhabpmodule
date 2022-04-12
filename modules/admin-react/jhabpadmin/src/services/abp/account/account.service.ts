import { request } from 'umi';
import type { LoginInput, LoginResponse } from '../account.models';

/**统一身份登录 */
export const accountLogin = async (input: LoginInput): Promise<LoginResponse> => {
  return await request<LoginResponse>(`/identityapi/account/login`, {
    method: 'POST',
    data: input,
  });
};

/**统一身份登出*/
export const accountLogout = async () => {
  return await request(`/identityapi/account/logout`, {
    method: 'GET',
  });
};
