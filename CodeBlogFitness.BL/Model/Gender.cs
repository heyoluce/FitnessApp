using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
	internal class Gender
	{
		public string Name { get; }

		public Gender(string name)
		{
			if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
			Name = name;
		}
	}
}                       