using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
	internal class User
	{
		public User(string name,
					Gender gender,
					DateTime birthDate,
					double weight,
					double height)
		{
			#region Проверка условий и присваивание
			if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Имя не может быть пустым", nameof(name));
			if (gender == null) throw new ArgumentNullException("Пол не может быть пустым", nameof(gender));
			if (birthDate < DateTime.Parse("01.01.1900") || birthDate>= DateTime.Now) throw new ArgumentException("Неверный ввод даты рождения", nameof(birthDate));
			if (weight< 0.0) throw new ArgumentException("Вес не может быть меньше нуля", nameof(weight));
			if (height< 0.0) throw new ArgumentException("Рост не может быть меньше нуля", nameof(height));
			
			Name = name;
			Gender = gender;
			BirthDate = birthDate;
			Weight = weight;
			Height = height;
			#endregion
		}

		public string Name { get; }

		public Gender Gender { get; }

		public DateTime BirthDate { get; }

		public double Weight { get; set; }

		public double Height { get; set; }
		public override string ToString()
		{
			return base.ToString();
		}
	}
}
