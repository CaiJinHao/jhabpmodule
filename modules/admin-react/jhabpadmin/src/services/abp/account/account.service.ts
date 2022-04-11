import { request } from 'umi';
import type { LoginInput } from '../models';

/**登录 */
export const accountLogin = async (input: LoginInput): Promise<any> => {
  return await request<any>(`/identity/api/account/login`, {
    method: 'POST',
    data: input,
  });
};

/**登出 */
export const accountLogout = async () => {
  return await request(`/identity/api/account/logout`, {
    method: 'GET',
  });
};
