using CodeBlogFitness.BL.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/// Контроллер пользователя
namespace CodeBlogFitness.BL.Controller
{
	public class UserController : ControllerBase
	{
		public List<User> Users { get; }
		public User CurrentUser { get;  }
		public bool IsNewUser { get; } = false;

		public UserController(string userName)
		{
			if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));

			Users = GetUsersData();

			CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

			if (CurrentUser==null)
			{
				IsNewUser = true;
				CurrentUser = new User(userName);
				Users.Add(CurrentUser);
				Save();
			}
			
		}
		/// <summary>
		/// Cохранение данных пользователя
		/// </summary>
		public void Save()
		{
			Save(Users);

		}
		/// <summary>
		/// Получение cписок данных пользователей
		/// </summary>
		/// <returns></returns>
		private List<User> GetUsersData()
		{
			return Load<User>() ?? new List<User>();
			
		}
		public void SetNewUserData(string genderName, DateTime birthDate, double weight=1, double height=1)
		{
			//TODO: Проверка

			CurrentUser.Gender = new Gender(genderName);
			CurrentUser.BirthDate = birthDate;
			CurrentUser.Weight = weight;
			CurrentUser.Height = height;
			Save();
		}
	}
}
