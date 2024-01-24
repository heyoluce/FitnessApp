using CodeBlogFitness.BL.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;


namespace CodeBlogFitness.BL.Controller
{
	public class DataSaver : IDataSaver 
	{
		public List<T> Load<T>() where T: class
		{
			using (var db = new FitnessContext())
			{
				return db.Set<T>().Where(l => true).ToList();
			}
		}


		public void Save<T>(List<T> item) where T : class 
		{
			using (var db = new FitnessContext())
		{
			db.Set<T>().AddRange(item); 
				db.SaveChanges();
		}
		}

		
	}
}
