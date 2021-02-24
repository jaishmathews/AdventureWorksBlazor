using AdventureWorks.Business.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.API.Tests
{
	[TestClass()]
	public class TestBase
	{
		protected static List<Product> ProductsList { get; private set; }

		[AssemblyInitialize()]
		public static void AssemblyInit(TestContext context)
		{
			ProductsList = new List<Product>();
			ProductsList.Add(new Product { ProductId = 100, Name = "Product1", ProductNumber = "1000", StandardCost = 1000, SellStartDate = DateTime.Today, Color = null, Size = null });
			ProductsList.Add(new Product { ProductId = 200, Name = "Product2", ProductNumber = "2000", StandardCost = 1000, SellStartDate = DateTime.Today, Color = null, Size = null });
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