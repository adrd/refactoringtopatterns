using System.Collections.Generic;
using EncapsulateClassesWithFactory.InitialCode.Descriptors;
using EncapsulateClassesWithFactory.InitialCode.Mappers;
using NUnit.Framework;

namespace RefactoringToPatterns.Tests.EncapsulateClassesWithFactory.InitialCode.Mappers
{
    [TestFixture]
    public class DescriptorMapperTests
    {
        TestingDescriptorMapper testDescriptorMapper;

		[SetUp]
        public void Init()
        {
            this.testDescriptorMapper = new TestingDescriptorMapper();
        }

        [Test]
        public void it_maps_remoteId_descriptor_as_DefaultDescriptor()
        {
            var remoteIdDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("remoteId");
            
            Assert.IsInstanceOf(typeof(DefaultDescriptor),remoteIdDescriptor);
        }

        [Test]
		public void it_maps_createdDate_descriptor_as_DefaultDescriptor()
		{
			var createdDateDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("createdDate");
            
		    Assert.IsInstanceOf(typeof(DefaultDescriptor), createdDateDescriptor);
        }

		[Test]
		public void it_maps_lastChangedDate_descriptor_as_DefaultDescriptor()
		{
			var lastChangedDateDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("lastChangedDate");
            
		    Assert.IsInstanceOf(typeof(DefaultDescriptor), lastChangedDateDescriptor);
        }

		[Test]
		public void it_maps_createdBy_descriptor_as_ReferenceDescriptor()
		{
            var createdByDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("createdBy");
            
		    Assert.IsInstanceOf(typeof(ReferenceDescriptor), createdByDescriptor);
        }

		[Test]
		public void it_maps_lastChangedBy_descriptor_ReferenceDescriptor()
		{
			var lastChangedByDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("lastChangedBy");
            
		    Assert.IsInstanceOf(typeof(ReferenceDescriptor), lastChangedByDescriptor);
        }

		[Test]
		public void it_maps_optimisticLockVersion_descriptor_as_DefaultDescriptor()
		{
			var optimisticLockVersionDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("optimisticLockVersion");
            
		    Assert.IsInstanceOf(typeof(DefaultDescriptor), optimisticLockVersionDescriptor);
        }

		[Test]
		public void it_does_not_map_unknown_descriptors()
		{
            var unknownDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("unknown");
            
			Assert.Null(unknownDescriptor);
		}
    }

    internal class TestingDescriptorMapper : DescriptorMapper {
        List<AttributeDescriptor> descriptors;

        public TestingDescriptorMapper() {
            this.descriptors = this.CreateAttributeDescriptors();
        }

		public AttributeDescriptor GetMappedDescriptorFor(string descriptorName)
		{
			return this.descriptors.Find(descriptor => descriptor.DescriptorName == descriptorName);
		}
    }
}

