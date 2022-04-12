//account

export interface LoginInput {
  userNameOrEmailAddress?: string;
  password?: string;
  rememberMe?: boolean;
  type?: string;
}

export interface LoginResponse {
  result?: number;
  description?: string;
  type?: string;
}
