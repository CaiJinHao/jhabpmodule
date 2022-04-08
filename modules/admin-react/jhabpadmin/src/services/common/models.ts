export interface TreeDto {
  id?: string;
  title?: string;
  name?: string;
  url?: string;
  href?: string;
  icon?: string;
  parent_id?: string;
  spread: boolean;
  checked: boolean;
  disabled: boolean;
  obj: object;
  sort?: string;
  children: TreeDto[];
  data: TreeDto[];
  value?: string;
}
