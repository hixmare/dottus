using System;

namespace Dottus.Core
{
    public static class Extensions
    {
        public static VertexAttribute? DescribeVertexAttribute(this Type self)
        {
            var att = Attribute.GetCustomAttribute(self, typeof(VertexDescriptorAttribute)) as VertexDescriptorAttribute;
            if (att == null) { return null; }
            return att.ToVertexAttribute();
        }

        public static VertexAttribute[] DescribeVertexAttributes(this Type self)
        {
            var att = Attribute.GetCustomAttribute(self, typeof(VertexDescriptorAttribute)) as VertexDescriptorAttribute;
            if (att == null) { return null; }
            return att.ToVertexAttributes();
        }

    }
}