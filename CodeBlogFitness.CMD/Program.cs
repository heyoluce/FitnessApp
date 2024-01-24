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
			var culture = CultureInfo.CreateSpecificCulture("ru-RU");
			var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));

			Console.WriteLine(resourceManager.GetString("EnterName", culture));
			string name = Console.ReadLine();
			var userController = new UserController(name);
			var eatingController = new EatingController(userController.CurrentUser);
			var exerciseController = new ExerciseController(userController.CurrentUser);
			if (userController.IsNewUser)
			{
				Console.WriteLine("Введите пол: ");
				string gender = Console.ReadLine();

				DateTime birthDate = ParseDateTime("дата рождения");

				var weight = ParseDouble("вес");

				var height = ParseDouble("рост");

				userController.SetNewUserData(gender, birthDate, weight, height);
			}
			Console.WriteLine(userController.CurrentUser);

			while (true)
			{
				Console.WriteLine("Что вы хотите сделать?: ");
				Console.WriteLine("Е - ввести прием пищи");
				Console.WriteLine("A - ввести упражение");
				Console.WriteLine("Q - выход");
				var key = Console.ReadKey();
				Console.WriteLine();

				switch (key.Key)
				{
					case ConsoleKey.E:
						var foods = EnterEating();
						eatingController.Add(foods.Food, foods.Weight);

						foreach (var item in eatingController.Eating.Foods)
						{
							Console.WriteLine($"\t{item.Key} - {item.Value}");
						}
						break;
					case ConsoleKey.A:
						var exe = EnterExercise();
						exerciseController.Add(exe.Acvtivity, exe.Start, exe.End);

						foreach(var item in exerciseController.Exercises)

						{
							Console.WriteLine($"{item.Activity} c {item.Start.ToShortTimeString()} по {item.End.ToShortTimeString()}");
                        }
						break;
					case ConsoleKey.Q:
						Environment.Exit(0);
						break;

				}
			}

		}
			private static (DateTime Start, DateTime End, Activity Acvtivity) EnterExercise()
		{
			Console.WriteLine("Введите название упражнения:");
			var name = Console.ReadLine();

			var energy = ParseDouble("расход энергии в минуту");
			var start = ParseDateTime("начало упражнения");
			var end = ParseDateTime("конец упражнения");

			var activity = new Activity(name, energy);
			return (start, end, activity);
		}
			private static (Food Food, double Weight) EnterEating()
		{
			Console.WriteLine("Введите имя продукта: ");
			var foodName = Console.ReadLine();

			var callories = ParseDouble("калорийность");
			var prots = ParseDouble("белки");
			var carbs= ParseDouble("углеводы");
			var fats= ParseDouble("жиры");

			var weight = ParseDouble("вес");
			var product = new Food(foodName, callories, prots, fats, carbs);
			return (product, weight); 
        }
			private static DateTime ParseDateTime(string value)
			{
				do
				{
					Console.WriteLine($"Введите {value} в формате (дд.мм.гггг):");
					string input = Console.ReadLine();

				if (DateTime.TryParseExact(input, "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
				{
					return birthDate;
					}
					else
					{
						Console.WriteLine("Неверный формат даты. Пожалуйста, введите дату в формате (дд.мм.гггг чч::мм).");
					}

				} while (true);
			}

			private static double ParseDouble(string prompt)
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

