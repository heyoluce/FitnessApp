﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;
namespace CodeBlogFitness.BL.Controller
{
	public class EatingController : ControllerBase
	{
		private const string FOODS_FILE_NAME = "foods.dat";
		private const string EATINGS_FILE_NAME = "eatings.dat";
		private readonly User user;
		public List<Food> Foods { get;  }
		public Eating Eating { get; }
	
		public EatingController(User user)
		{
			this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
			Foods = GetAllFoods();
			Eating = GetEating();
		}

		public void Add(Food food, double weight)
		{
			var product = Foods.SingleOrDefault(f => f.Name == food.Name);
			if (product == null)
			{
				Foods.Add(food);
				Eating.Add(food, weight);
				Save();
			}
			else
			{
				Eating.Add(product, weight);
				Save();
			}
		}
		private List<Food> GetAllFoods()
		{
			return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
			 
		}
		private Eating GetEating()
		{
			return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);

		}

		private void Save()
		{
			Save<List<Food>>(FOODS_FILE_NAME, Foods);
			Save<Eating>(EATINGS_FILE_NAME, Eating);
		}


	}
}
