using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>   //this is to replace the includes in the product
    {                                                       //repository\
        public BaseSpecification()
        {
        }       
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {   
            Criteria = criteria;
        }   
        public Expression<Func<T, bool>> Criteria {get; } 

        public List<Expression<Func<T, object>>> Includes {get; } =   // this creates new list
            new List<Expression<Func<T, object>>>();
        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}