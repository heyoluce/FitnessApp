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
		public DateTime Start {  get;  }
		public DateTime End { get;  }

		public Activity Activity { get;  }
		public User User { get; }

		public Exercise (DateTime start, DateTime end, Activity activity, User user)
		{
			// Проверка
			Start = start;
			End = end;
			Activity = activity;
			User = user;
		}
	}
}
