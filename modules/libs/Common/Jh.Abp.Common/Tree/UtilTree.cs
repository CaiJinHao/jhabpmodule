﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Jh.Abp.Common
{
    public class UtilTree
    {
        public static async Task<List<T>> GetMenusTreeAsync<T>(List<T> menus,string Sorting="sort") where T : TreeDto
        {
            var _type = typeof(T);
            //组装树
            async Task<IEnumerable<T>> GetChildNodesAsync(string parentNodeId)
            {
                var childs = menus.Where(a => a.parent_id == parentNodeId);
                foreach (var item in childs)
                {
                    var _data = await GetChildNodesAsync(item.id);
                    item.children = (_data as IEnumerable<TreeDto>).OrderBy(a => a.sort);
                }
                return childs.OrderBy(a => a.sort).ToList();
            }

            //找到根节点
            var roots = menus.Where(a => a.parent_id == null || a.parent_id == "").OrderBy(a => a.sort).ToList();
            foreach (var item in roots)
            {
                var _data = await GetChildNodesAsync(item.id);
                item.children = (_data as IEnumerable<TreeDto>).OrderBy(a=>a.sort);
            }
            return roots;
        }

        public static async Task<List<T>> GetTreeByAntdAsync<T>(List<T> menus) where T : TreeAntdDto
        {
            var _type = typeof(T);
            //组装树
            async Task<IEnumerable<T>> GetChildNodesAsync(string parentNodeId)
            {
                var childs = menus.Where(a => a.parentId == parentNodeId);
                foreach (var item in childs)
                {
                    var _data = await GetChildNodesAsync(item.id);
                    item.children = (_data as IEnumerable<TreeAntdDto>).OrderBy(a => a.order).ToList();
                    if (item.children.Count==0)
                    {
                        item.isLeaf = true;
                    }
                }
                return childs.OrderBy(a => a.order).ToList();
            }

            //找到根节点
            var roots = menus.Where(a => a.parentId == null).OrderBy(a => a.order).ToList();
            foreach (var item in roots)
            {
                var _data = await GetChildNodesAsync(item.id);
                item.children = (_data as IEnumerable<TreeAntdDto>).OrderBy(a => a.order).ToList();
                if (item.children.Count == 0)
                {
                    item.isLeaf = true;
                }
            }
            return roots;
        }
    }
}
