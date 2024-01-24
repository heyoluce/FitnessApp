using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
	[Serializable]
	public class Gender
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Gender(string name)
		{
			if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
			Name = name;
		}

		public Gender()
		{
		}
	}
}                       