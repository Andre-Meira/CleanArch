using CleanArc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArch.Domain.Tests
{
	public class ProductUnitTest
	{
		[Fact (DisplayName = "Create Product With Valid State")]
		public void CreateProduct_WithValidParameters_ResultObjectValidState()
		{
			Action action = () => new Product(1, "Product Name", "Product Descrition", 9.9m, 99, "Product Image");
			action.Should()
				.NotThrow<CleanArc.Domain.Validation.DomainExecpetionValidation>();
		}

		[Fact (DisplayName = "Create Product With Negative Id Value State")]
		public void CreateProduct_NegativeIdValue_DomainExepectionInvalidId()
		{
			Action action = () => new Product(-1, "Product Name", "Product Descrition", 9.9m, 99, "Product Image");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid id value!");
		}

		[Fact (DisplayName = "Create Product Missing Name Value")]
		public void CreateProduct_MissingNameValue_DomainExecptionInvalidName()
		{
			Action action = () => new Product(1, "", "Product Descrition", 9.9m, 99, "Product Image");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid name. Name is required!");
		}

		[Fact (DisplayName = "Create Product Null Name Value")]
		public void CreateProduct_WithNullNameValue_DomainExecptionInvalidName()
		{
			Action action = () => new Product(1, null, "Product Descrition", 9.9m, 99, "Product Image");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid name. Name is required!");
		}

		[Fact (DisplayName = "Create Product With Short Name Value State ")]
		public void CreateProduct_ShortsNameValue_DomainExecpetionInvalidName()
		{
			Action action = () => new Product(1, "Pr", "Product Descrition", 9.9m, 99, "Product Image");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid name, too short, minimum 3 caracters!");
		}

		[Fact (DisplayName = "Create Product Missing Description Value State ")]
		public void CreateProduct_MissingDescriptionValue_DomainExecpetionInvalidDescription()
		{
			Action action = () => new Product(1, "Product Name", "", 9.9m, 99, "Product Image");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid description. Description is required!");
		}

		[Fact (DisplayName = "Create Product with Null Description Value State")]
		public void CreateProduct_WithNullDescriptionValue_DomainExecpetionInvalidDescription() 
		{
			Action action = () => new Product(1, "Product Name", null, 9.9m, 99, "Product Image");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid description. Description is required!");
		}

		[Fact (DisplayName = "Create Product Short Description Value State")]
		public void CreateProduct_ShortDescriptionValue_DomainExecpetionInvalidDescription()
		{
			Action action = () => new Product(1, "Product Name", "Desc", 9.9m, 99, "Product Image");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid Description, too short, minimum 5 caracters!");
		}

		[Fact (DisplayName = "Create Product With Negavite Price Value State")]
		public void CreateProduct_WithNegativePriceValue_DomainExecpetionInvalidPrice() 
		{
			Action action = () => new Product(1, "Product Name", "Product Descprition", -9.9m, 99, "Product Image");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>();
		}

		[Fact (DisplayName = "Create Product with Negative Value State")]
		public void CreateProduct_WithNegativestockValue_DomainExeceptionInvalidStock() 
		{
			Action action = () => new Product(1, "Product Name", "Product Descprition", 9.9m, -99, "Product Image");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>();
		}

		[Fact(DisplayName = "Create Product Short Image Value State")]
		public void CreateProduct_ShortImageValue_DomainExecpetionInvalidImage() 		
		{
			Action action = () => new Product(1, "Product Name", "Product Descprition", 9.9m, 99, 
				"Product Imageeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
				"eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
				"eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee" +
				"eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid image name, too long, maximum 250 caracters!");
		}
	}
}
