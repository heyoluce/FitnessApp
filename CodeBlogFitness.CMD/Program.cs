using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Controller;
namespace CodeBlogFitness.CMD
{
	public class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("Вас приветствует фитнес - приложение");

			Console.WriteLine("Введите имя пользователя: ");
			string name = Console.ReadLine();
			var userController = new UserController(name);
			if (userController.IsNewUser)
			{
				Console.WriteLine("Введите пол: ");
				string gender = Console.ReadLine();

				DateTime birthDate = GetBirthDate();

				var weight = GetDoubleInput("вес");

				var height = GetDoubleInput("рост");

				userController.SetNewUserData(gender, birthDate, weight, height);
			}
			Console.WriteLine(userController.CurrentUser);
			Console.ReadLine();

		}
			private static DateTime GetBirthDate()
			{
				do
				{
					Console.WriteLine("Введите дату рождения в формате (дд.мм.гггг):");
					string input = Console.ReadLine();

					if (DateTime.TryParseExact(input, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
					{
						return birthDate;
					}
					else
					{
						Console.WriteLine("Неверный формат даты. Пожалуйста, введите дату в формате (дд.мм.гггг).");
					}

				} while (true);
			}

			private static double GetDoubleInput(string prompt)
			{
				Console.WriteLine($"Введите {prompt} :");
            do
				{
					string input = Console.ReadLine();

					if (double.TryParse(input, out double result))
					{
						return result;
					}
					else
					{
						Console.WriteLine("Неверный формат числа. Пожалуйста, введите число.");
					}

				} while (true);
			}

		}
	}

