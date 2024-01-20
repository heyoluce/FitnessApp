using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
	[Serializable]
	public class User
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

		public User(string name)
		{
			if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Имя не может быть пустым", nameof(name));
			Name = name;
		}

		public string Name { get; }

		public Gender Gender { get; set; }

		public DateTime BirthDate { get; set; }

		public double Weight { get; set; }

		public double Height { get; set; }

		public int Age
		{
			get
			{
				// Рассчитываем возраст на основе разницы между текущей датой и датой рождения.
				DateTime currentDate = DateTime.Now;
				int age = currentDate.Year - BirthDate.Year;

				// Уменьшаем возраст, если день рождения еще не наступил в текущем году.
				if (currentDate < BirthDate.AddYears(age))
				{
					age--;
				}

				return age;
			}
		}
		public override string ToString()
		{
			return Name + " (" + Age + ")";
		}
	}
}
