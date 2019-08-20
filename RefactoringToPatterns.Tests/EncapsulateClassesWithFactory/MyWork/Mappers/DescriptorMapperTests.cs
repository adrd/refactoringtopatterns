using System.Collections.Generic;
using EncapsulateClassesWithFactory.MyWork.Descriptors;
using EncapsulateClassesWithFactory.MyWork.Mappers;
using NUnit.Framework;

namespace RefactoringToPatterns.Tests.EncapsulateClassesWithFactory.MyWork.Mappers
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
            AttributeDescriptor remoteIdDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("remoteId");
            
            Assert.AreEqual("DefaultDescriptor", remoteIdDescriptor.GetType().Name);
        }

        [Test]
		public void it_maps_createdDate_descriptor_as_DefaultDescriptor()
		{
			AttributeDescriptor createdDateDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("createdDate");
            
		    Assert.AreEqual("DefaultDescriptor", createdDateDescriptor.GetType().Name);
        }

		[Test]
		public void it_maps_lastChangedDate_descriptor_as_DefaultDescriptor()
		{
			AttributeDescriptor lastChangedDateDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("lastChangedDate");
            
		    Assert.AreEqual("DefaultDescriptor", lastChangedDateDescriptor.GetType().Name);
        }

		[Test]
		public void it_maps_createdBy_descriptor_as_ReferenceDescriptor()
		{
            AttributeDescriptor createdByDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("createdBy");
            
		    Assert.AreEqual("ReferenceDescriptor", createdByDescriptor.GetType().Name);
        }

		[Test]
		public void it_maps_lastChangedBy_descriptor_ReferenceDescriptor()
		{
			AttributeDescriptor lastChangedByDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("lastChangedBy");
            
		    Assert.AreEqual("ReferenceDescriptor", lastChangedByDescriptor.GetType().Name);
        }

		[Test]
		public void it_maps_optimisticLockVersion_descriptor_as_DefaultDescriptor()
		{
			AttributeDescriptor optimisticLockVersionDescriptor = 
                this.testDescriptorMapper.GetMappedDescriptorFor("optimisticLockVersion");
            
		    Assert.AreEqual("DefaultDescriptor", optimisticLockVersionDescriptor.GetType().Name);
        }

		[Test]
		public void it_does_not_map_unknown_descriptors()
		{
            AttributeDescriptor unknownDescriptor = 
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

