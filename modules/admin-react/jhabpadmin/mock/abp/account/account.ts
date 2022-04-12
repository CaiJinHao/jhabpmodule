import { Request, Response } from 'express';
const { ANT_DESIGN_PRO_ONLY_DO_NOT_USE_IN_YOUR_PRODUCTION } = process.env;

/**
 * 当前用户的权限，如果为空代表没登录
 * current user access， if is '', user need login
 * 如果是 pro 的预览，默认是有权限的
 */
let access = ANT_DESIGN_PRO_ONLY_DO_NOT_USE_IN_YOUR_PRODUCTION === 'site' ? 'admin' : '';

export default {
  'POST /identityapi/account/login': async (req: Request, res: Response) => {
    const { password, userNameOrEmailAddress, rememberMe, type } = req.body;
    if (password === 'KimHo@123' && userNameOrEmailAddress === 'admin') {
      res.send({
        result: 1,
        description: 'success',
        rememberMe,
        currentAuthority: 'admin',
        type: type,
      });
      access = 'admin';
      return;
    }

    res.send({
      result: 2,
      description: 'InvalidUserNameOrPassword',
      type: type,
      rememberMe,
      currentAuthority: 'guest',
    });
    access = 'guest';
  },
};
