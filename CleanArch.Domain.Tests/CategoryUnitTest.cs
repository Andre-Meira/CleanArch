using CleanArc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArch.Domain.Tests
{
	public class CategoryUnitTest
	{
		[Fact (DisplayName ="Create Category With Valid State")]
		public void CreateCategory_WithValidParameters_ResultObjectValidState()
		{
			Action action = () => new Category(1, "Category Name");
			action.Should()
				.NotThrow<CleanArc.Domain.Validation.DomainExecpetionValidation>();				
		}

		[Fact (DisplayName = "Create Category With Negative Id Value state")]
		public void CreateCategory_NegativeIdValue_DomainExecpetionInvalidId()
		{
			Action action = () => new Category(-1, "Category Name");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid id value");
		}

		[Fact (DisplayName = "Create Category With Short Name Value state")]
		public void CreateCategory_ShortNameValue_DomainExecpetionShortName()
		{
			Action action = () => new Category(1, "Ca");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid name. Too Shorts, minimum 3 charecters");			
		}

		[Fact(DisplayName = "Create Category Missing Name Value")]
		public void CreateCategory_MissingNameValue_DomainExecpetionRequeridName()
		{
			Action action = () => new Category(1, "");
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>()
				.WithMessage("Invalid name.Name is required");
		}

		[Fact(DisplayName = "Create Category With Null Name Value state")]
		public void CreateCategory_WithNullNameValue_DomainExecpetionInvalidName() 
		{
			Action action = () => new Category(1, null);
			action.Should()
				.Throw<CleanArc.Domain.Validation.DomainExecpetionValidation>();						
		}

	}
}
