using AdventureWorks.DataAccess.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

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

			InMemoryAdventureWorksLT2019Context.Products.Add(new Product { ProductId = 100, Name = "Product1", ProductNumber = "1000", StandardCost = 1000, SellStartDate = DateTime.Today, Color = null, Size = null });
			InMemoryAdventureWorksLT2019Context.Products.Add(new Product { ProductId = 200, Name = "Product2", ProductNumber = "2000", StandardCost = 1000, SellStartDate = DateTime.Today, Color = null, Size = null });
			InMemoryAdventureWorksLT2019Context.SaveChanges();
		}

		[ExcludeFromCodeCoverage]
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
		[ExcludeFromCodeCoverage]
		[ClassCleanup()]
		public static void ClassCleanup()
		{

		}

		[AssemblyCleanup()]
		public static void AssemblyCleanup()
		{

		}

	}
}