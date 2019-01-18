using eCommerce.Data.Domain.Entities;
using eCommerce.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Categories
{
    public class CategoryService :BaseService<Category>, ICategoryService<Category>
    {
        //private GenericUnitOfWork _unit = null;
        //public CategoryService()
        //{
        //    _unit = new GenericUnitOfWork();
        //}
        //public bool Any(Expression<Func<Category, bool>> where)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Delete(List<Category> Entity)
        //{
        //    _unit.Repository<Category>().Delete(Entity);
        //    return _unit.SaveChanges();
        //}

        //public bool Delete(Category Entity)
        //{
        //    _unit.Repository<Category>().Delete(Entity);
        //   return _unit.SaveChanges();
        //}

        //public bool Delete(int Id)
        //{
        //    _unit.Repository<Category>().Delete(Id); return _unit.SaveChanges();
        //}

        //public Category Get(Expression<Func<Category, bool>> where)
        //{
        //    throw new NotImplementedException();
        //}

        //public Category GetById(int Id)
        //{
        //    return _unit.Repository<Category>().GetById(Id);
        //}

        //public IList<Category> GetList()
        //{
        //    return _unit.Repository<Category>().GetList();
        //}

        //public IList<Category> GetList(Expression<Func<Category, bool>> where)
        //{
        //    return _unit.Repository<Category>().GetList(where);
        //}

        //public Category Insert(Category Entity)
        //{
        //    _unit.Repository<Category>().Insert(Entity);
        //    _unit.SaveChanges();
        //    return Entity;
        //}

        //public bool Update(Category Entity)
        //{
        //    _unit.Repository<Category>().Update(Entity);
        //    return _unit.SaveChanges();

        //}
        public IList<Category> PrepareCategoryList()
        {
            var model = new List<Category>();
            var categories = GetList();
            foreach (var item in categories)
            {
                var _category = new Category();
                _category.Name = GetCategoryHierarcyName(item);
                _category.Description = item.Description;
                _category.CreatedDate = item.CreatedDate;
                _category.CreatedById = item.CreatedById;
                _category.Id = item.Id;
                _category.IsActive = item.IsActive;
                _category.OrderNo = item.OrderNo;
                _category.ParantId = item.ParantId;
                _category.Published = item.Published;
                model.Add(_category);
            }
            return model;
        }

        private string GetCategoryHierarcyName(Category category)
        {
            var seperator = ">>";
            var breadcrumb = "";
            var result = new List<Category>();
            var usedIds = new List<int>();
            while (category != null && !usedIds.Contains(category.Id))
            {
                result.Add(category);
                usedIds.Add(category.Id);
                category = GetList().FirstOrDefault(x => x.Id == category.ParantId);
            }
            result.Reverse();
            for (int i = 0; i <= result.Count - 1; i++)
            {
                var CategoryName = result[i].Name;
                breadcrumb = string.IsNullOrEmpty(breadcrumb) ? CategoryName : string.Format("{0} {1} {2}", breadcrumb, seperator, CategoryName);
            }
            return breadcrumb;
        }

      
    }
}
