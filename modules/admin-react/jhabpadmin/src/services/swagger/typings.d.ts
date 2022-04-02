declare namespace API {
  
  type TreeDto =
     {
      'id'?: string;
      'title'?: string;
      'name'?: string;
      'url'?: string;
      'href'?: string;
      'icon'?: string;
      'parent_id'?: string;
      'spread'?: boolean;
      'checked'?: boolean;
      'disabled'?: boolean;
      'obj'?: any;
      'sort'?: string;
      'children'?: TreeDto[];
      'data'?: TreeDto[];
      'value'?: string;
     }
    

  type AccessTokenRequestDto =
     {
      /** 用户名或者邮箱地址 */
      'userNameOrEmailAddress': string;
      /** 密码 */
      'password': string;
      'organizationName'?: string;
     }
    

  type AccessTokenResponseDto =
     {
      'accessToken'?: string;
      'expiresIn'?: number;
      'tokenType'?: string;
      'refreshToken'?: string;
     }
    

  type ChangePasswordInputDto =
     {
      'currentPassword'?: string;
      'newPassword': string;
     }
    

  type IdentityRoleCreateInputDto =
     {
      'extraProperties'?: Record<string, any>;
      'name'?: string;
      'normalizedName'?: string;
      'isDefault'?: boolean;
      'isStatic'?: boolean;
      'isPublic'?: boolean;
      /** 并发检测字段 必须和数据库中的值一样才会允许更新 */
      'concurrencyStamp'?: string;
     }
    

  type IdentityRoleDto =
     {
      'extraProperties'?: Record<string, any>;
      'id'?: string;
      'name'?: string;
      'normalizedName'?: string;
      'isDefault'?: boolean;
      'isStatic'?: boolean;
      'isPublic'?: boolean;
      /** 并发标识 */
      'concurrencyStamp'?: string;
      'tenantId'?: string;
     }
    

  type IdentityRoleUpdateInputDto =
     {
      'extraProperties'?: Record<string, any>;
      'name'?: string;
      'normalizedName'?: string;
      'isDefault'?: boolean;
      'isStatic'?: boolean;
      'isPublic'?: boolean;
      /** 并发检测字段 必须和数据库中的值一样才会允许更新 */
      'concurrencyStamp'?: string;
     }
    

  type IdentityUserCreateInputDto =
      IdentityUserCreateOrUpdateDto
    

  type IdentityUserCreateOrUpdateDto =
     {
      'extraProperties'?: Record<string, any>;
      'userName': string;
      'name'?: string;
      'surname'?: string;
      'email': string;
      'phoneNumber'?: string;
      'isActive'?: boolean;
      'lockoutEnabled'?: boolean;
      'roleNames'?: string[];
      'organizationUnitIds'?: string[];
     }
    

  type IdentityUserDto =
     {
      'extraProperties'?: Record<string, any>;
      'id'?: string;
      'creationTime'?: string;
      'creatorId'?: string;
      'lastModificationTime'?: string;
      'lastModifierId'?: string;
      'isDeleted'?: boolean;
      'deleterId'?: string;
      'deletionTime'?: string;
      'userName'?: string;
      'normalizedUserName'?: string;
      'name'?: string;
      'surname'?: string;
      'email'?: string;
      'normalizedEmail'?: string;
      'emailConfirmed'?: boolean;
      'passwordHash'?: string;
      'securityStamp'?: string;
      'isExternal'?: boolean;
      'phoneNumber'?: string;
      'phoneNumberConfirmed'?: boolean;
      'twoFactorEnabled'?: boolean;
      'lockoutEnd'?: string;
      'lockoutEnabled'?: boolean;
      'accessFailedCount'?: number;
      'isActive'?: boolean;
      /** 并发标识 */
      'concurrencyStamp'?: string;
      'tenantId'?: string;
      'organizationUnitIds'?: string[];
      'roleIds'?: string[];
     }
    

  type IdentityUserUpdateInputDto =
      IdentityUserCreateOrUpdateDto
    

  type OrganizationUnitCreateInputDto =
     {
      'extraProperties'?: Record<string, any>;
      'parentId'?: string;
      'displayName'?: string;
      /** 并发检测字段 必须和数据库中的值一样才会允许更新 */
      'concurrencyStamp'?: string;
      'roleIds'?: string[];
     }
    

  type OrganizationUnitDto =
     {
      'extraProperties'?: Record<string, any>;
      'id'?: string;
      'creationTime'?: string;
      'creatorId'?: string;
      'lastModificationTime'?: string;
      'lastModifierId'?: string;
      'isDeleted'?: boolean;
      'deleterId'?: string;
      'deletionTime'?: string;
      'parentId'?: string;
      'code'?: string;
      'displayName'?: string;
      'tenantId'?: string;
      /** 并发标识 */
      'concurrencyStamp'?: string;
     }
    

  type OrganizationUnitUpdateInputDto =
     {
      'extraProperties'?: Record<string, any>;
      'parentId'?: string;
      'displayName'?: string;
      /** 是否删除 */
      'isDeleted'?: boolean;
      /** 并发检测字段 必须和数据库中的值一样才会允许更新 */
      'concurrencyStamp'?: string;
      'roleIds'?: string[];
     }
    

  type SampleDto =
     {
      'value'?: number;
     }
    

  type MenuCreateInputDto =
     {
      'extraProperties'?: Record<string, any>;
      'menuCode': string;
      'menuName': string;
      'menuIcon': string;
      'menuSort': number;
      'menuParentCode'?: string;
      'menuUrl'?: string;
      'menuDescription'?: string;
      'menuPlatform': number;
      'concurrencyStamp'?: string;
      'roleIds'?: string[];
     }
    

  type MenuDto =
     {
      'extraProperties'?: Record<string, any>;
      'id'?: string;
      'creationTime'?: string;
      'creatorId'?: string;
      'lastModificationTime'?: string;
      'lastModifierId'?: string;
      'isDeleted'?: boolean;
      'deleterId'?: string;
      'deletionTime'?: string;
      'menuCode'?: string;
      'menuName'?: string;
      'menuIcon'?: string;
      'menuSort'?: number;
      'menuParentCode'?: string;
      'menuUrl'?: string;
      'menuDescription'?: string;
      'menuPlatform'?: number;
      'tenantId'?: string;
      'concurrencyStamp'?: string;
     }
    

  type MenuRoleMapCreateInputDto =
     {
      'menuIds': string[];
      'roleIds': string[];
     }
    

  type MenuRoleMapDto =
     {
      'id'?: string;
      'creationTime'?: string;
      'creatorId'?: string;
      'menuId'?: string;
      'roleId'?: string;
      'tenantId'?: string;
     }
    

  type MenuUpdateInputDto =
     {
      'extraProperties'?: Record<string, any>;
      'menuCode'?: string;
      'menuName'?: string;
      'menuIcon'?: string;
      'menuSort'?: number;
      'menuParentCode'?: string;
      'menuUrl'?: string;
      'menuDescription'?: string;
      'menuPlatform'?: number;
      'concurrencyStamp'?: string;
      'isDeleted'?: boolean;
     }
    

  type SampleDto =
     {
      'value'?: number;
     }
    

  type PermissionGrantedCreateInputDto =
     {
      /** 权限名称列表 */
      'permissionNames'?: string[];
      'providerName'?: string;
      'providerKey'?: string;
     }
    

  type PermissionGrantedDto =
     {
      'tenantId'?: string;
      'name'?: string;
      'granted'?: boolean;
     }
    

  type PermissionGrantedRetrieveInputDto =
     {
      'tenantId'?: string;
      'permissionNames'?: string[];
      'providerName'?: string;
      'providerKey'?: string;
     }
    

  type BacklogResultType = 0 | 1 | 2 | 3;

  type SampleDto =
     {
      'value'?: number;
     }
    

  type WorkflowBacklogCreateInputDto =
     {
      'workflowInstanceId': string;
      'backlogUserId'?: string;
      'backlogUserName'?: string;
      'backlogHandleTime'?: string;
      'backlogResult': (BacklogResultType);
      'backlogRemark'?: string;
     }
    

  type WorkflowBacklogDto =
     {
      'id'?: string;
      'creationTime'?: string;
      'creatorId'?: string;
      'workflowInstanceId'?: string;
      'backlogUserId'?: string;
      'backlogUserName'?: string;
      'backlogHandleTime'?: string;
      'backlogResult'?: (BacklogResultType);
      'backlogRemark'?: string;
      'tenantId'?: string;
      'eventName'?: string;
      'eventKey'?: string;
      'businessType'?: number;
      'businessDataId'?: string;
     }
    

  type WorkflowBacklogUpdateInputDto =
     {
      'workflowInstanceId'?: string;
      'backlogUserId'?: string;
      'backlogUserName'?: string;
      'backlogHandleTime'?: string;
      'backlogResult'?: (BacklogResultType);
      'backlogRemark'?: string;
      'isDeleted'?: boolean;
     }
    

  type WorkflowDefinitionCreateInputDto =
     {
      'extraProperties'?: Record<string, any>;
      'version': number;
      'description'?: string;
      'jsonDefinition'?: string;
      'inputData'?: string;
      'formDefinition'?: string;
      'businessType': number;
      'concurrencyStamp'?: string;
     }
    

  type WorkflowDefinitionDto =
     {
      'extraProperties'?: Record<string, any>;
      'id'?: string;
      'creationTime'?: string;
      'creatorId'?: string;
      'lastModificationTime'?: string;
      'lastModifierId'?: string;
      'isDeleted'?: boolean;
      'deleterId'?: string;
      'deletionTime'?: string;
      'version'?: number;
      'description'?: string;
      'jsonDefinition'?: string;
      'inputData'?: string;
      'formDefinition'?: string;
      'businessType'?: number;
      'concurrencyStamp'?: string;
      'tenantId'?: string;
     }
    

  type WorkflowDefinitionUpdateInputDto =
     {
      'extraProperties'?: Record<string, any>;
      'version'?: number;
      'description'?: string;
      'jsonDefinition'?: string;
      'inputData'?: string;
      'formDefinition'?: string;
      'businessType'?: number;
      'isDeleted'?: boolean;
      'concurrencyStamp'?: string;
     }
    

  type WorkflowInstanceDto =
     {
      'id'?: string;
      'creationTime'?: string;
      'creatorId'?: string;
      'workflowDefinitionId'?: string;
      'version'?: number;
      'description'?: string;
      'reference'?: string;
      'nextExecution'?: number;
      'data'?: string;
      'completeTime'?: string;
      'status'?: (WorkflowStatus);
      'businessType'?: number;
      'businessDataId'?: string;
      'tenantId'?: string;
     }
    

  type WorkflowPublishEventDto =
     {
      'eventData'?: any;
      'backlogId': string;
     }
    

  type WorkflowStartDto =
     {
      'id'?: string;
      'version'?: number;
      'data'?: any;
     }
    

  type WorkflowStepDto =
     {
      'id'?: string;
      'name'?: string;
      'description'?: string;
      'stepType'?: string;
      'inputs'?: any;
      'outputs'?: any;
      'className'?: string;
      'assemblyName'?: string;
     }
    

  type HttpStatusCode = 100 | 101 | 102 | 103 | 200 | 201 | 202 | 203 | 204 | 205 | 206 | 207 | 208 | 226 | 300 | 301 | 302 | 303 | 304 | 305 | 306 | 307 | 308 | 400 | 401 | 402 | 403 | 404 | 405 | 406 | 407 | 408 | 409 | 410 | 411 | 412 | 413 | 414 | 415 | 416 | 417 | 421 | 422 | 423 | 424 | 426 | 428 | 429 | 431 | 451 | 500 | 501 | 502 | 503 | 504 | 505 | 506 | 507 | 508 | 510 | 511;

  type ChangePasswordInput =
     {
      'currentPassword'?: string;
      'newPassword': string;
     }
    

  type ProfileDto =
     {
      'extraProperties'?: Record<string, any>;
      'userName'?: string;
      'email'?: string;
      'name'?: string;
      'surname'?: string;
      'phoneNumber'?: string;
      'isExternal'?: boolean;
      'hasPassword'?: boolean;
      'concurrencyStamp'?: string;
     }
    

  type RegisterDto =
     {
      'extraProperties'?: Record<string, any>;
      'userName': string;
      'emailAddress': string;
      'password': string;
      'appName': string;
     }
    

  type ResetPasswordDto =
     {
      'userId'?: string;
      'resetToken': string;
      'password': string;
     }
    

  type SendPasswordResetCodeDto =
     {
      'email': string;
      'appName': string;
      'returnUrl'?: string;
      'returnUrlHash'?: string;
     }
    

  type UpdateProfileDto =
     {
      'extraProperties'?: Record<string, any>;
      'userName'?: string;
      'email'?: string;
      'name'?: string;
      'surname'?: string;
      'phoneNumber'?: string;
      'concurrencyStamp'?: string;
     }
    

  type AbpLoginResult =
     {
      'result'?: (LoginResultType);
      'description'?: string;
     }
    

  type LoginResultType = 1 | 2 | 3 | 4 | 5;

  type UserLoginInfo =
     {
      'userNameOrEmailAddress': string;
      'password': string;
      'rememberMe'?: boolean;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: TreeDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: IdentityRoleDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: IdentityUserDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: OrganizationUnitDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: MenuDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: WorkflowBacklogDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: WorkflowDefinitionDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: WorkflowInstanceDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: WorkflowStepDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: AuditLog[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: IdentityRoleDto[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: UserData[];
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: IdentityRoleDto[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: IdentityUserDto[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: OrganizationUnitDto[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: MenuDto[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: WorkflowBacklogDto[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: WorkflowDefinitionDto[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: WorkflowInstanceDto[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: AuditLog[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: IdentityRoleDto[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: IdentityUserDto[];
      'totalCount'?: number;
     }
    

  type 0CultureneutralPublicKeyTokennull =
     {
      'items'?: TenantDto[];
      'totalCount'?: number;
     }
    

  type ApplicationAuthConfigurationDto =
     {
      'policies'?: Record<string, any>;
      'grantedPolicies'?: Record<string, any>;
     }
    

  type ApplicationConfigurationDto =
     {
      'localization'?: (ApplicationLocalizationConfigurationDto);
      'auth'?: (ApplicationAuthConfigurationDto);
      'setting'?: (ApplicationSettingConfigurationDto);
      'currentUser'?: (CurrentUserDto);
      'features'?: (ApplicationFeatureConfigurationDto);
      'multiTenancy'?: (MultiTenancyInfoDto);
      'currentTenant'?: (CurrentTenantDto);
      'timing'?: (TimingDto);
      'clock'?: (ClockDto);
      'objectExtensions'?: (ObjectExtensionsDto);
     }
    

  type ApplicationFeatureConfigurationDto =
     {
      'values'?: Record<string, any>;
     }
    

  type ApplicationLocalizationConfigurationDto =
     {
      'values'?: Record<string, any>;
      'languages'?: LanguageInfo[];
      'currentCulture'?: (CurrentCultureDto);
      'defaultResourceName'?: string;
      'languagesMap'?: Record<string, any>;
      'languageFilesMap'?: Record<string, any>;
     }
    

  type ApplicationSettingConfigurationDto =
     {
      'values'?: Record<string, any>;
     }
    

  type ClockDto =
     {
      'kind'?: string;
     }
    

  type CurrentCultureDto =
     {
      'displayName'?: string;
      'englishName'?: string;
      'threeLetterIsoLanguageName'?: string;
      'twoLetterIsoLanguageName'?: string;
      'isRightToLeft'?: boolean;
      'cultureName'?: string;
      'name'?: string;
      'nativeName'?: string;
      'dateTimeFormat'?: (DateTimeFormatDto);
     }
    

  type CurrentUserDto =
     {
      'isAuthenticated'?: boolean;
      'id'?: string;
      'tenantId'?: string;
      'impersonatorUserId'?: string;
      'impersonatorTenantId'?: string;
      'impersonatorUserName'?: string;
      'impersonatorTenantName'?: string;
      'userName'?: string;
      'name'?: string;
      'surName'?: string;
      'email'?: string;
      'emailVerified'?: boolean;
      'phoneNumber'?: string;
      'phoneNumberVerified'?: boolean;
      'roles'?: string[];
     }
    

  type DateTimeFormatDto =
     {
      'calendarAlgorithmType'?: string;
      'dateTimeFormatLong'?: string;
      'shortDatePattern'?: string;
      'fullDateTimePattern'?: string;
      'dateSeparator'?: string;
      'shortTimePattern'?: string;
      'longTimePattern'?: string;
     }
    

  type IanaTimeZone =
     {
      'timeZoneName'?: string;
     }
    

  type EntityExtensionDto =
     {
      'properties'?: Record<string, any>;
      'configuration'?: Record<string, any>;
     }
    

  type ExtensionEnumDto =
     {
      'fields'?: ExtensionEnumFieldDto[];
      'localizationResource'?: string;
     }
    

  type ExtensionEnumFieldDto =
     {
      'name'?: string;
      'value'?: any;
     }
    

  type ExtensionPropertyApiCreateDto =
     {
      'isAvailable'?: boolean;
     }
    

  type ExtensionPropertyApiDto =
     {
      'onGet'?: (ExtensionPropertyApiGetDto);
      'onCreate'?: (ExtensionPropertyApiCreateDto);
      'onUpdate'?: (ExtensionPropertyApiUpdateDto);
     }
    

  type ExtensionPropertyApiGetDto =
     {
      'isAvailable'?: boolean;
     }
    

  type ExtensionPropertyApiUpdateDto =
     {
      'isAvailable'?: boolean;
     }
    

  type ExtensionPropertyAttributeDto =
     {
      'typeSimple'?: string;
      'config'?: Record<string, any>;
     }
    

  type ExtensionPropertyDto =
     {
      'type'?: string;
      'typeSimple'?: string;
      'displayName'?: (LocalizableStringDto);
      'api'?: (ExtensionPropertyApiDto);
      'ui'?: (ExtensionPropertyUiDto);
      'attributes'?: ExtensionPropertyAttributeDto[];
      'configuration'?: Record<string, any>;
      'defaultValue'?: any;
     }
    

  type ExtensionPropertyUiDto =
     {
      'onTable'?: (ExtensionPropertyUiTableDto);
      'onCreateForm'?: (ExtensionPropertyUiFormDto);
      'onEditForm'?: (ExtensionPropertyUiFormDto);
      'lookup'?: (ExtensionPropertyUiLookupDto);
     }
    

  type ExtensionPropertyUiFormDto =
     {
      'isVisible'?: boolean;
     }
    

  type ExtensionPropertyUiLookupDto =
     {
      'url'?: string;
      'resultListPropertyName'?: string;
      'displayPropertyName'?: string;
      'valuePropertyName'?: string;
      'filterParamName'?: string;
     }
    

  type ExtensionPropertyUiTableDto =
     {
      'isVisible'?: boolean;
     }
    

  type LocalizableStringDto =
     {
      'name'?: string;
      'resource'?: string;
     }
    

  type ModuleExtensionDto =
     {
      'entities'?: Record<string, any>;
      'configuration'?: Record<string, any>;
     }
    

  type ObjectExtensionsDto =
     {
      'modules'?: Record<string, any>;
      'enums'?: Record<string, any>;
     }
    

  type TimeZone =
     {
      'iana'?: (IanaTimeZone);
      'windows'?: (WindowsTimeZone);
     }
    

  type TimingDto =
     {
      'timeZone'?: (TimeZone);
     }
    

  type WindowsTimeZone =
     {
      'timeZoneId'?: string;
     }
    

  type CurrentTenantDto =
     {
      'id'?: string;
      'name'?: string;
      'isAvailable'?: boolean;
     }
    

  type FindTenantResultDto =
     {
      'success'?: boolean;
      'tenantId'?: string;
      'name'?: string;
      'isActive'?: boolean;
     }
    

  type MultiTenancyInfoDto =
     {
      'isEnabled'?: boolean;
     }
    

  type EntityChangeType = 0 | 1 | 2;

  type AuditLog =
     {
      'id'?: string;
      'extraProperties'?: Record<string, any>;
      'concurrencyStamp'?: string;
      'applicationName'?: string;
      'userId'?: string;
      'userName'?: string;
      'tenantId'?: string;
      'tenantName'?: string;
      'impersonatorUserId'?: string;
      'impersonatorUserName'?: string;
      'impersonatorTenantId'?: string;
      'impersonatorTenantName'?: string;
      'executionTime'?: string;
      'executionDuration'?: number;
      'clientIpAddress'?: string;
      'clientName'?: string;
      'clientId'?: string;
      'correlationId'?: string;
      'browserInfo'?: string;
      'httpMethod'?: string;
      'url'?: string;
      'exceptions'?: string;
      'comments'?: string;
      'httpStatusCode'?: number;
      'entityChanges'?: EntityChange[];
      'actions'?: AuditLogAction[];
     }
    

  type AuditLogAction =
     {
      'id'?: string;
      'tenantId'?: string;
      'auditLogId'?: string;
      'serviceName'?: string;
      'methodName'?: string;
      'parameters'?: string;
      'executionTime'?: string;
      'executionDuration'?: number;
      'extraProperties'?: Record<string, any>;
     }
    

  type EntityChange =
     {
      'id'?: string;
      'auditLogId'?: string;
      'tenantId'?: string;
      'changeTime'?: string;
      'changeType'?: (EntityChangeType);
      'entityTenantId'?: string;
      'entityId'?: string;
      'entityTypeFullName'?: string;
      'propertyChanges'?: EntityPropertyChange[];
      'extraProperties'?: Record<string, any>;
     }
    

  type EntityPropertyChange =
     {
      'id'?: string;
      'tenantId'?: string;
      'entityChangeId'?: string;
      'newValue'?: string;
      'originalValue'?: string;
      'propertyName'?: string;
      'propertyTypeFullName'?: string;
     }
    

  type FeatureDto =
     {
      'name'?: string;
      'displayName'?: string;
      'value'?: string;
      'provider'?: (FeatureProviderDto);
      'description'?: string;
      'valueType'?: (IStringValueType);
      'depth'?: number;
      'parentName'?: string;
     }
    

  type FeatureGroupDto =
     {
      'name'?: string;
      'displayName'?: string;
      'features'?: FeatureDto[];
     }
    

  type FeatureProviderDto =
     {
      'name'?: string;
      'key'?: string;
     }
    

  type GetFeatureListResultDto =
     {
      'groups'?: FeatureGroupDto[];
     }
    

  type UpdateFeatureDto =
     {
      'name'?: string;
      'value'?: string;
     }
    

  type UpdateFeaturesDto =
     {
      'features'?: UpdateFeatureDto[];
     }
    

  type ActionApiDescriptionModel =
     {
      'uniqueName'?: string;
      'name'?: string;
      'httpMethod'?: string;
      'url'?: string;
      'supportedVersions'?: string[];
      'parametersOnMethod'?: MethodParameterApiDescriptionModel[];
      'parameters'?: ParameterApiDescriptionModel[];
      'returnValue'?: (ReturnValueApiDescriptionModel);
      'allowAnonymous'?: boolean;
      'implementFrom'?: string;
     }
    

  type ApplicationApiDescriptionModel =
     {
      'modules'?: Record<string, any>;
      'types'?: Record<string, any>;
     }
    

  type ControllerApiDescriptionModel =
     {
      'controllerName'?: string;
      'controllerGroupName'?: string;
      'type'?: string;
      'interfaces'?: ControllerInterfaceApiDescriptionModel[];
      'actions'?: Record<string, any>;
     }
    

  type ControllerInterfaceApiDescriptionModel =
     {
      'type'?: string;
     }
    

  type MethodParameterApiDescriptionModel =
     {
      'name'?: string;
      'typeAsString'?: string;
      'type'?: string;
      'typeSimple'?: string;
      'isOptional'?: boolean;
      'defaultValue'?: any;
     }
    

  type ModuleApiDescriptionModel =
     {
      'rootPath'?: string;
      'remoteServiceName'?: string;
      'controllers'?: Record<string, any>;
     }
    

  type ParameterApiDescriptionModel =
     {
      'nameOnMethod'?: string;
      'name'?: string;
      'jsonName'?: string;
      'type'?: string;
      'typeSimple'?: string;
      'isOptional'?: boolean;
      'defaultValue'?: any;
      'constraintTypes'?: string[];
      'bindingSourceId'?: string;
      'descriptorName'?: string;
     }
    

  type PropertyApiDescriptionModel =
     {
      'name'?: string;
      'jsonName'?: string;
      'type'?: string;
      'typeSimple'?: string;
      'isRequired'?: boolean;
     }
    

  type ReturnValueApiDescriptionModel =
     {
      'type'?: string;
      'typeSimple'?: string;
     }
    

  type TypeApiDescriptionModel =
     {
      'baseType'?: string;
      'isEnum'?: boolean;
      'enumNames'?: string[];
      'enumValues'?: any[];
      'genericArguments'?: string[];
      'properties'?: PropertyApiDescriptionModel[];
     }
    

  type RemoteServiceErrorInfo =
     {
      'code'?: string;
      'message'?: string;
      'details'?: string;
      'data'?: Record<string, any>;
      'validationErrors'?: RemoteServiceValidationErrorInfo[];
     }
    

  type RemoteServiceErrorResponse =
     {
      'error'?: (RemoteServiceErrorInfo);
     }
    

  type RemoteServiceValidationErrorInfo =
     {
      'message'?: string;
      'members'?: string[];
     }
    

  type IdentityRoleCreateDto =
      IdentityRoleCreateOrUpdateDtoBase
    

  type IdentityRoleCreateOrUpdateDtoBase =
     {
      'extraProperties'?: Record<string, any>;
      'name': string;
      'isDefault'?: boolean;
      'isPublic'?: boolean;
     }
    

  type IdentityRoleDto =
     {
      'extraProperties'?: Record<string, any>;
      'id'?: string;
      'name'?: string;
      'isDefault'?: boolean;
      'isStatic'?: boolean;
      'isPublic'?: boolean;
      'concurrencyStamp'?: string;
     }
    

  type IdentityRoleUpdateDto =
      IdentityRoleCreateOrUpdateDtoBase
    

  type IdentityUserCreateDto =
      IdentityUserCreateOrUpdateDtoBase
    

  type IdentityUserCreateOrUpdateDtoBase =
     {
      'extraProperties'?: Record<string, any>;
      'userName': string;
      'name'?: string;
      'surname'?: string;
      'email': string;
      'phoneNumber'?: string;
      'isActive'?: boolean;
      'lockoutEnabled'?: boolean;
      'roleNames'?: string[];
     }
    

  type IdentityUserDto =
     {
      'extraProperties'?: Record<string, any>;
      'id'?: string;
      'creationTime'?: string;
      'creatorId'?: string;
      'lastModificationTime'?: string;
      'lastModifierId'?: string;
      'isDeleted'?: boolean;
      'deleterId'?: string;
      'deletionTime'?: string;
      'tenantId'?: string;
      'userName'?: string;
      'name'?: string;
      'surname'?: string;
      'email'?: string;
      'emailConfirmed'?: boolean;
      'phoneNumber'?: string;
      'phoneNumberConfirmed'?: boolean;
      'isActive'?: boolean;
      'lockoutEnabled'?: boolean;
      'lockoutEnd'?: string;
      'concurrencyStamp'?: string;
     }
    

  type IdentityUserUpdateDto =
      IdentityUserCreateOrUpdateDtoBase
    

  type IdentityUserUpdateRolesDto =
     {
      'roleNames': string[];
     }
    

  type LanguageInfo =
     {
      'cultureName'?: string;
      'uiCultureName'?: string;
      'displayName'?: string;
      'flagIcon'?: string;
     }
    

  type NameValue =
      0CultureneutralPublicKeyToken7cec85d7bea7798e
    

  type 0CultureneutralPublicKeyToken7cec85d7bea7798e =
     {
      'name'?: string;
      'value'?: string;
     }
    

  type GetPermissionListResultDto =
     {
      'entityDisplayName'?: string;
      'groups'?: PermissionGroupDto[];
     }
    

  type PermissionGrantInfoDto =
     {
      'name'?: string;
      'displayName'?: string;
      'parentName'?: string;
      'isGranted'?: boolean;
      'allowedProviders'?: string[];
      'grantedProviders'?: ProviderInfoDto[];
     }
    

  type PermissionGroupDto =
     {
      'name'?: string;
      'displayName'?: string;
      'permissions'?: PermissionGrantInfoDto[];
     }
    

  type ProviderInfoDto =
     {
      'providerName'?: string;
      'providerKey'?: string;
     }
    

  type UpdatePermissionDto =
     {
      'name'?: string;
      'isGranted'?: boolean;
     }
    

  type UpdatePermissionsDto =
     {
      'permissions'?: UpdatePermissionDto[];
     }
    

  type EmailSettingsDto =
     {
      'smtpHost'?: string;
      'smtpPort'?: number;
      'smtpUserName'?: string;
      'smtpPassword'?: string;
      'smtpDomain'?: string;
      'smtpEnableSsl'?: boolean;
      'smtpUseDefaultCredentials'?: boolean;
      'defaultFromAddress'?: string;
      'defaultFromDisplayName'?: string;
     }
    

  type UpdateEmailSettingsDto =
     {
      'smtpHost'?: string;
      'smtpPort'?: number;
      'smtpUserName'?: string;
      'smtpPassword'?: string;
      'smtpDomain'?: string;
      'smtpEnableSsl'?: boolean;
      'smtpUseDefaultCredentials'?: boolean;
      'defaultFromAddress': string;
      'defaultFromDisplayName': string;
     }
    

  type TenantCreateDto =
      TenantCreateOrUpdateDtoBase
    

  type TenantCreateOrUpdateDtoBase =
     {
      'extraProperties'?: Record<string, any>;
      'name': string;
     }
    

  type TenantDto =
     {
      'extraProperties'?: Record<string, any>;
      'id'?: string;
      'name'?: string;
      'concurrencyStamp'?: string;
     }
    

  type TenantUpdateDto =
      TenantCreateOrUpdateDtoBase
    

  type UserData =
     {
      'id'?: string;
      'tenantId'?: string;
      'userName'?: string;
      'name'?: string;
      'surname'?: string;
      'email'?: string;
      'emailConfirmed'?: boolean;
      'phoneNumber'?: string;
      'phoneNumberConfirmed'?: boolean;
     }
    

  type IStringValueType =
     {
      'name'?: string;
      'properties'?: Record<string, any>;
      'validator'?: (IValueValidator);
     }
    

  type IValueValidator =
     {
      'name'?: string;
      'properties'?: Record<string, any>;
     }
    

  type ExecutionPointer =
     {
      'id'?: string;
      'stepId'?: number;
      'active'?: boolean;
      'sleepUntil'?: string;
      'persistenceData'?: any;
      'startTime'?: string;
      'endTime'?: string;
      'eventName'?: string;
      'eventKey'?: string;
      'eventPublished'?: boolean;
      'eventData'?: any;
      'extensionAttributes'?: Record<string, any>;
      'stepName'?: string;
      'retryCount'?: number;
      'children'?: string[];
      'contextItem'?: any;
      'predecessorId'?: string;
      'outcome'?: any;
      'status'?: (PointerStatus);
      'scope'?: string[];
     }
    

  type PointerStatus = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9;

  type WorkflowInstance =
     {
      'id'?: string;
      'workflowDefinitionId'?: string;
      'version'?: number;
      'description'?: string;
      'reference'?: string;
      'executionPointers'?: ExecutionPointer[];
      'nextExecution'?: number;
      'status'?: (WorkflowStatus);
      'data'?: any;
      'createTime'?: string;
      'completeTime'?: string;
     }
    

  type WorkflowStatus = 0 | 1 | 2 | 3;

  type undefinedParams =
     {
      'includeTypes'?: boolean;
     }
    

  type undefinedParams =
     {
      'name': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'refreshToken'?: string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'startTime'?: string;
      'endTime'?: string;
      'httpMethod'?: string;
      'url'?: string;
      'userId'?: string;
      'userName'?: string;
      'applicationName'?: string;
      'clientIpAddress'?: string;
      'correlationId'?: string;
      'maxExecutionDuration'?: number;
      'minExecutionDuration'?: number;
      'hasException'?: boolean;
      'httpStatusCode'?: (HttpStatusCode);
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'startTime'?: string;
      'endTime'?: string;
      'httpMethod'?: string;
      'url'?: string;
      'userId'?: string;
      'userName'?: string;
      'applicationName'?: string;
      'clientIpAddress'?: string;
      'correlationId'?: string;
      'maxExecutionDuration'?: number;
      'minExecutionDuration'?: number;
      'hasException'?: boolean;
      'httpStatusCode'?: (HttpStatusCode);
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'startTime'?: string;
      'endTime'?: string;
      'httpMethod'?: string;
      'url'?: string;
      'userId'?: string;
      'userName'?: string;
      'applicationName'?: string;
      'clientIpAddress'?: string;
      'correlationId'?: string;
      'maxExecutionDuration'?: number;
      'minExecutionDuration'?: number;
      'hasException'?: boolean;
      'httpStatusCode'?: (HttpStatusCode);
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'providerName'?: string;
      'providerKey'?: string;
     }
    

  type undefinedParams =
     {
      'providerName'?: string;
      'providerKey'?: string;
     }
    

  type undefinedParams =
     {
      'name'?: string;
      'normalizedName'?: string;
      'isDefault'?: boolean;
      'isStatic'?: boolean;
      'isPublic'?: boolean;
      'methodInput.stringTypeQueryMethod'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'name'?: string;
      'normalizedName'?: string;
      'isDefault'?: boolean;
      'isStatic'?: boolean;
      'isPublic'?: boolean;
      'methodInput.stringTypeQueryMethod'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'name'?: string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'name'?: string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'userName'?: string;
      'normalizedUserName'?: string;
      'name'?: string;
      'surname'?: string;
      'email'?: string;
      'normalizedEmail'?: string;
      'emailConfirmed'?: boolean;
      'passwordHash'?: string;
      'securityStamp'?: string;
      'isExternal'?: boolean;
      'phoneNumber'?: string;
      'phoneNumberConfirmed'?: boolean;
      'twoFactorEnabled'?: boolean;
      'lockoutEnd'?: string;
      'lockoutEnabled'?: boolean;
      'accessFailedCount'?: number;
      /** 是否删除 */
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      'organizationUnitId'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'userName'?: string;
      'normalizedUserName'?: string;
      'name'?: string;
      'surname'?: string;
      'email'?: string;
      'normalizedEmail'?: string;
      'emailConfirmed'?: boolean;
      'passwordHash'?: string;
      'securityStamp'?: string;
      'isExternal'?: boolean;
      'phoneNumber'?: string;
      'phoneNumberConfirmed'?: boolean;
      'twoFactorEnabled'?: boolean;
      'lockoutEnd'?: string;
      'lockoutEnabled'?: boolean;
      'accessFailedCount'?: number;
      /** 是否删除 */
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      'organizationUnitId'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'userName'?: string;
      'normalizedUserName'?: string;
      'name'?: string;
      'surname'?: string;
      'email'?: string;
      'normalizedEmail'?: string;
      'emailConfirmed'?: boolean;
      'passwordHash'?: string;
      'securityStamp'?: string;
      'isExternal'?: boolean;
      'phoneNumber'?: string;
      'phoneNumberConfirmed'?: boolean;
      'twoFactorEnabled'?: boolean;
      'lockoutEnd'?: string;
      'lockoutEnabled'?: boolean;
      'accessFailedCount'?: number;
      /** 是否删除 */
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      'organizationUnitId'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'userId': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'tenantId'?: string;
      'permissionNames'?: string[];
      'providerName'?: string;
      'providerKey'?: string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'providerName'?: string;
      'providerKey'?: string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'providerName'?: string;
      'providerKey'?: string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      'menuCode'?: string;
      'menuName'?: string;
      'sort'?: number;
      'menuParentCode'?: string;
      'orMenuCode'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      'menuCode'?: string;
      'menuName'?: string;
      'sort'?: number;
      'menuParentCode'?: string;
      'orMenuCode'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'parentCode': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'methodInput.stringTypeQueryMethod'?: string;
      'tenantId'?: string;
      'menuId'?: string;
      'roleId'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'parentId'?: string;
      'code'?: string;
      'displayName'?: string;
      /** 是否删除 */
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      /** 组织树查询 上级及下级 */
      'orParentId'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'parentId'?: string;
      'code'?: string;
      'displayName'?: string;
      /** 是否删除 */
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      /** 组织树查询 上级及下级 */
      'orParentId'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'name'?: string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'roleId': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'providerName'?: string;
      'providerKey'?: string;
     }
    

  type undefinedParams =
     {
      'providerName'?: string;
      'providerKey'?: string;
     }
    

  type undefinedParams =
     {
      'filter'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'filter'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'defaultConnectionString'?: string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'filter'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'userName': string;
     }
    

  type undefinedParams =
     {
      'email': string;
     }
    

  type undefinedParams =
     {
      'id': string;
     }
    

  type undefinedParams =
     {
      'userName': string;
     }
    

  type undefinedParams =
     {
      'filter'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
     }
    

  type undefinedParams =
     {
      'filter'?: string;
     }
    

  type undefinedParams =
     {
      'backlogUserId'?: string;
      'backlogResult'?: (BacklogResultType);
      'businessType'?: number;
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'backlogUserId'?: string;
      'backlogResult'?: (BacklogResultType);
      'businessType'?: number;
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'id': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'deleted'?: number;
      'methodInput.stringTypeQueryMethod'?: string;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'methodInput.stringTypeQueryMethod'?: string;
      'tenantId'?: string;
      'creatorId'?: string;
      'status'?: (WorkflowStatus);
      'businessType'?: number;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'methodInput.stringTypeQueryMethod'?: string;
      'tenantId'?: string;
      'creatorId'?: string;
      'status'?: (WorkflowStatus);
      'businessType'?: number;
      'sorting'?: string;
      'skipCount'?: number;
      'maxResultCount'?: number;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'workflowId': string;
      'apiVersion': string;
     }
    

  type undefinedParams =
     {
      'apiVersion': string;
     }
    

}