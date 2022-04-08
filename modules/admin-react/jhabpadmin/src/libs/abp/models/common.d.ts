// import { eLayoutType } from '../enums/common';
// import { Environment } from './environment';
export declare namespace ABP {
  interface Root {
    environment: Partial<Environment>;
    registerLocaleFn: (locale: string) => Promise<any>;
    skipGetAppConfiguration?: boolean;
    sendNullsAsQueryParam?: boolean;
    tenantKey?: string;
    localizations?: Localization[];
  }
  interface Child {
    localizations?: Localization[];
  }
  interface Localization {
    culture: string;
    resources: LocalizationResource[];
  }
  interface LocalizationResource {
    resourceName: string;
    texts: Record<string, string>;
  }
  interface HasPolicy {
    requiredPolicy?: string;
  }
  interface Test extends Partial<Root> {
    baseHref?: string;
    listQueryDebounceTime?: number;
    routes?: Routes;
  }
  type PagedResponse<T> = {
    totalCount: number;
  } & PagedItemsResponse<T>;
  interface PagedItemsResponse<T> {
    items: T[];
  }
  interface PageQueryParams {
    filter?: string;
    sorting?: string;
    skipCount?: number;
    maxResultCount?: number;
  }
  interface Lookup {
    id: string;
    displayName: string;
  }
  interface Nav {
    name: string;
    parentName?: string;
    requiredPolicy?: string;
    order?: number;
    invisible?: boolean;
  }
  interface Route extends Nav {
    path?: string;
    layout?: eLayoutType;
    iconClass?: string;
  }
  interface Tab extends Nav {
    component: Type<any>;
  }
  interface BasicItem {
    id: string;
    name: string;
  }
  interface Option<T> {
    key: Extract<keyof T, string>;
    value: T[Extract<keyof T, string>];
  }
  type Dictionary<T> = Record<string, T>;
  type ExtractFromOutput<T extends EventEmitter<any> | Subject<any>> = T extends EventEmitter<
    infer X
  >
    ? X
    : T extends Subject<infer Y>
    ? Y
    : never;
}
