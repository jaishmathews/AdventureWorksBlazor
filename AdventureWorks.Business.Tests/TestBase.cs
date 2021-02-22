using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.DataAccess.Models;
using AutoMapper;

namespace AdventureWorks.Business.Tests
{
	[TestClass()]
	public class TestBase
	{
		private static readonly DbContextOptions<AdventureWorksLT2019Context> dbContextOptions = new DbContextOptionsBuilder<AdventureWorksLT2019Context>()
				.UseInMemoryDatabase(databaseName: "AdventureWorksLT2019")
				.Options;
		protected static AdventureWorksLT2019Context InMemoryAdventureWorksLT2019Context { get; private set; }
		protected static IMapper Mapper { get; private set; }

		[AssemblyInitialize()]
		public static void AssemblyInit(TestContext context)
		{
			InMemoryAdventureWorksLT2019Context = new AdventureWorksLT2019Context(dbContextOptions);
			if (Mapper == null)
			{
				var mappingConfig = new MapperConfiguration(mc =>
				{
					mc.AddProfile(new MappingProfile());
				});
				IMapper mapper = mappingConfig.CreateMapper();
				Mapper = mapper;
			}
		}

		[ClassInitialize()]
		public static void ClassInit(TestContext context)
		{

		}

		[TestInitialize()]
		public void Initialize()
		{

		}

		[TestCleanup()]
		public void Cleanup()
		{

		}

		[ClassCleanup()]
		public static void ClassCleanup()
		{

		}

		[AssemblyCleanup()]
		public static void AssemblyCleanup()
		{

		}

		[TestMethod()]
		[ExpectedException(typeof(System.DivideByZeroException))]
		public void DivideMethodTest()
		{

		}
	}
}