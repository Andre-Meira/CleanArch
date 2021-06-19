﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArc.Domain.Validation;

namespace CleanArc.Domain.Entities
{
	public sealed class Product : Entity
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public decimal Price { get; private set; }
		public int Stock { get; private set; }
		public string Image { get; private set; }

		public Product(string name, string description, decimal price, int stock, string image) 
		{
			ValidateDomain(name,description,price,stock,image);
		
		}

		public Product(int id, string name, string description, decimal price, int stock, string image) 
		{
			DomainExecpetionValidation.When(id < 0, "Invalid id value!");
			Id = id;
			ValidateDomain(name, description, price, stock, image);
		}

		public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
		{
			ValidateDomain(name, description, price, stock, image);
			CategoryId = categoryId;
		}

		public int CategoryId { get; set; }
		public Category Category { get; set; }

		private void ValidateDomain(string name, string description, decimal price, int stock, string image) 
		{
			DomainExecpetionValidation.When(string.IsNullOrEmpty(name), 
				"Invalid name. Name is required!");
			DomainExecpetionValidation.When(name.Length < 3,
				"Invalid name, too short, minimum 3 caracters!");
			DomainExecpetionValidation.When(string.IsNullOrEmpty(description),
				"Invalid description. Description is required!");
			DomainExecpetionValidation.When(description.Length < 5,
				"Invalid Description, too short, minimum 5 caracters!");
			DomainExecpetionValidation.When(price < 0, "Invalid price value!");
			DomainExecpetionValidation.When(stock < 0, "Invalid stock value!");
			DomainExecpetionValidation.When(image?.Length > 250,
				"Invalid image name, too long, maximum 250 caracters!");

			Name = name;
			Description = description;
			Price = price;
			Stock = stock;
			Image = image;

		}

	}
}