using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
	[Serializable]
	public class Exercise
	{
		public int Id { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }

		public virtual Activity Activity { get;  }
		public virtual User User { get; set; }
		public int UserId { get; set; }

		public Exercise (DateTime start, DateTime end, Activity activity, User user)
		{
			// Проверка
			Start = start;
			End = end;
			Activity = activity;
			User = user;
		}

		public Exercise()
		{
		}
	}
}
