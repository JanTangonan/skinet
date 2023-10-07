using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity 
    {   
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // p => p.ProductTypeId == id
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            
            if (spec.OrderByDescending != null) 
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            //this will return all the includes in the ProductRepository
            // return await context.Products
            //     .Include(p => p.ProductType)
            //     .Include(p => p.ProductBrand)
            //     .FirstOrDefaultAsync(p => p.Id == id);

            //this will return an IQueriable
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        } 
    }
}