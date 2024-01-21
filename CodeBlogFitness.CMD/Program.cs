using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System.Globalization;
using System.Resources;
namespace CodeBlogFitness.CMD
{
	public class Program
	{
		static void Main(string[] args)
		{
			var culture = CultureInfo.CreateSpecificCulture("en-US");
			var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));

			Console.WriteLine(resourceManager.GetString("EnterName", culture));
			string name = Console.ReadLine();
			var userController = new UserController(name);
			var eatingController = new EatingController(userController.CurrentUser);
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

            Console.WriteLine("Что вы хотите сделать?: ");
            Console.WriteLine("Е - ввести прием пищи");
			var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
			{
				var foods = EnterEating();
				eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
				{
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

		}
			private static (Food Food, double Weight) EnterEating()
		{
			Console.WriteLine("Введите имя продукта: ");
			var foodName = Console.ReadLine();

			var callories = GetDoubleInput("калорийность");
			var prots = GetDoubleInput("белки");
			var carbs= GetDoubleInput("углеводы");
			var fats= GetDoubleInput("жиры");

			var weight = GetDoubleInput("вес");
			var product = new Food(foodName, callories, prots, fats, carbs);
			return (product, weight); 
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

