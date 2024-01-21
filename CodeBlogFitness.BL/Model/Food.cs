using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
	[Serializable]
	public class Food
	{
		public string Name { get; set; }
		/// <summary>
		/// Белки
		/// </summary>
		
		public double Proteins { get;  }
		/// <summary>
		/// Углеводы
		/// </summary>
		public double Carbohydrates { get;  }
		/// <summary>
		/// Жиры
		/// </summary>
		public double Fats { get;  }
		/// <summary>
		/// Каллории
		/// </summary>
		public double Callories { get; }


		public Food (string name, double proteins, double carbohydrates, double fats, double calories)
		{
			// TODO: проверка
			Name = name;
			Proteins = proteins / 100.0;
			Carbohydrates = carbohydrates / 100.0;
			Fats = fats / 100.0;
			Callories = calories / 100.0;
		}
		
		public Food(string name)
		{
			// TODO: проверка
			Name = name;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
