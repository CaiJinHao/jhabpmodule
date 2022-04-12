//account

export interface LoginInput {
  userNameOrEmailAddress?: string;
  password?: string;
  rememberMe?: boolean;
}

export interface LoginResponse {
  result: number;
  description: string;
}
