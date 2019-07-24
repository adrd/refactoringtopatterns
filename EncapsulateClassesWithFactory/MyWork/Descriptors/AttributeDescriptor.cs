using System;
using EncapsulateClassesWithFactory.MyWork.Domain;

namespace EncapsulateClassesWithFactory.MyWork.Descriptors
{
    public class AttributeDescriptor
    {
        readonly string descriptorName;
        readonly Type mapperType;
        readonly Type forType;

        protected AttributeDescriptor(string descriptorName, Type mapperType, Type forType)
        {
            this.descriptorName = descriptorName;
            this.mapperType = mapperType;
            this.forType = forType;
        }

        public string DescriptorName => descriptorName;

        public static AttributeDescriptor ForInteger(String descriptorName, Type mapperType)
        {
            return new DefaultDescriptor(descriptorName, mapperType, typeof(Int32));
        }

        public static AttributeDescriptor ForDate(String descriptorName, Type mapperType)
        {
            return new DefaultDescriptor(descriptorName, mapperType, typeof(DateTime));
        }

        public static AttributeDescriptor ForString(String descriptorName, Type mapperType)
        {
            return new DefaultDescriptor(descriptorName, mapperType, typeof(String));
        }

        public static AttributeDescriptor ForUser(string descriptorName, Type mapperType)
        {
            return new ReferenceDescriptor(descriptorName, mapperType, typeof(User));
        }

        public class DefaultDescriptor : AttributeDescriptor
        {
            public DefaultDescriptor(string descriptorName, Type mapperType, Type forType)
                : base(descriptorName, mapperType, forType)
            {
            }
        }

        public class BooleanDescriptor : AttributeDescriptor
        {
            public BooleanDescriptor(string descriptorName, Type mapperType, Type forType) 
                : base(descriptorName, mapperType, forType)
            {

            }
        }

        public class ReferenceDescriptor: AttributeDescriptor
        {
            public ReferenceDescriptor(string descriptorName, Type mapperType, Type forType)
                : base(descriptorName, mapperType, forType)
            {

            }
        }
    }
}