// @ts-ignore
/* eslint-disable */
import { request } from 'umi';

/** 此处后端没有提供注释 POST /api/account/register */
export async function postAccountRegister(body: API.RegisterDto, options?: { [key: string]: any }) {
  return request<API.IdentityUserDto>('/api/account/register', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/account/send-password-reset-code */
export async function postAccountSendPasswordResetCode(
  body: API.SendPasswordResetCodeDto,
  options?: { [key: string]: any },
) {
  return request<any>('/api/account/send-password-reset-code', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    data: body,
    ...(options || {}),
  });
}

/** 此处后端没有提供注释 POST /api/account/reset-password */
export async function postAccountResetPassword(
  body: API.ResetPasswordDto,
  options?: { [key: string]: any },
) {
  return request<any>('/api/account/reset-password', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json-patch+json',
    },
    data: body,
    ...(options || {}),
  });
}
