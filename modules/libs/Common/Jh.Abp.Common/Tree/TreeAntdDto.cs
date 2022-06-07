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
        public string order { get; set; }
        public string parentId { get; set; }
        public string id { get; set; }
        public object data { get; set; }
        public string key { get { return id; } }
        public string title { get; set; }
        /// <summary>
        /// 设置节点是否可被选中
        /// </summary>
        public bool selectable { get; set; } = true;
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
        /// <summary>
        /// 当树为 checkable 时，设置独立节点是否展示 Checkbox
        /// </summary>
        public bool checkable { get; set; }

        public List<TreeAntdDto> children { get; set; }
    }
}
