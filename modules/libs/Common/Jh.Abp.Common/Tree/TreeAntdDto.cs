using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Common
{
    public class TreeAntdDto
    {
        /// <summary>
        /// 排序值
        /// </summary>
        public string order { get; private set; }
        public string id { get; set; }
        public string title { get; private set; }
        public string parentId { get; set; }
        public object data { get; set; }
        public string key { get { return id; } }
        /// <summary>
        /// 设置为叶子节点 (设置了 loadData 时有效)。为 false 时会强制将其作为父节点
        /// </summary>
        public bool isLeaf { get; set; }
        /// <summary>
        /// 自定义图标。可接收组件，props 为当前节点 props
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 禁掉响应
        /// </summary>
        public bool disabled { get; set; }
        /// <summary>
        /// 禁掉 checkbox
        /// </summary>
        public bool disableCheckbox { get; set; }

        public List<TreeAntdDto> children { get; set; }

        public TreeAntdDto(string _id,string _title, string _order)
        {
            id= _id;
            title = _title;
            order = _order;
        }
    }
}
