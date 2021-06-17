using CleanArc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Domain.Entities
{
	public sealed class Category : Entity
	{
		
		public string Name { get; private set; }

		public Category(string name) 
		{
			ValidateDomain(name);				
		}
		public Category(int id, string name) 
		{
			DomainExecpetionValidation.When(id < 0, "Invalid Id Value");
			Id = id;
			ValidateDomain(name);
		}

		public void Update(string name)
		{
			ValidateDomain(name);
		}

		public ICollection<Product> Products { get; set; }

		private void ValidateDomain(string name) 
		{
			DomainExecpetionValidation.When(string.IsNullOrEmpty(name), 
				"Invalid name.Name is required");

			DomainExecpetionValidation.When(name.Length < 3, 
				"Invalid name. Too Shorts, minimum 3 charecters");

			Name = name;
		}
	}
}
