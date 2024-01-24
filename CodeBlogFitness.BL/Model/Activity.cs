using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
	[Serializable]
	public class Activity
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public double CaloriesPerMinute { get; set; }
		public virtual ICollection<Exercise> Exercises { get; set; }	

		public Activity(string name, double caloriesPerMinute) 
		{
			Name = name;
			CaloriesPerMinute = caloriesPerMinute;
		}

		public Activity()
		{
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
