using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;
namespace CodeBlogFitness.BL.Controller
{
	public class ExerciseController : ControllerBase
	{
		private const string EXERCISES_FILE_NAME = "exercises.dat";
		private const string ACTIVITIES_FILE_NAME = "activities.dat";
		private readonly User user;
		public List<Exercise> Exercises { get; }
		public List<Activity> Activities { get; }
		public ExerciseController(User user)
		{
			this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым",nameof(user));
			Exercises = GetAllExercises();
			Activities = GetAllActivities();
		}
		private List<Activity> GetAllActivities()
		{
			return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
		}
		private List<Exercise> GetAllExercises()
		{
			return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
		}
		public void Add(Activity activity, DateTime start, DateTime end)
		{
			var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act==null )
            {
				Activities.Add(activity);

				var exercise = new Exercise(start, end, activity, user);
				Exercises.Add(exercise);

            }
			else
			{
				var exercise = new Exercise(start, end, act, user);
				Exercises.Add(exercise); 
			}
			Save();
		}
		private void Save()
		{
			Save<List<Exercise>>(EXERCISES_FILE_NAME, Exercises);
			Save<List<Activity>>(ACTIVITIES_FILE_NAME, Exercises);
		}
	}
}
