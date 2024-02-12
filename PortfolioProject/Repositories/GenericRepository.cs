using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using PortfolioProject.Models.Entity;

namespace PortfolioProject.Repositories
{
	public class GenericRepository<T> where T:class, new()
	{
		DBPortfolioEntities db = new DBPortfolioEntities();
		
		public List<T> List()
		{
			return db.Set<T>().ToList();
		}
		public void TAdd(T p)
		{
			db.Set<T>().Add(p);
			db.SaveChanges();
		}
		public void TDelete(T p)
		{
			db.Set<T>().Remove(p);
			db.SaveChanges();
		}
		public void TUpdate(T p)
		{
			db.SaveChanges();
		}
		public T TGet(int id)
		{
			return db.Set<T>().Find(id);
		}
		public T TFind(Expression<Func<T,bool>> where)
		{
			return db.Set<T>().FirstOrDefault(where);
		}
	}
}