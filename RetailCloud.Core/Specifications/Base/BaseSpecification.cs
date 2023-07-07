using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RetailCloud.Core.Specifications.Base
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool isPagingEnabled { get; private set; }

        protected BaseSpecification<T> AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
            return this;
        }

        public BaseSpecification<T> AddOrderBy(Expression<Func<T, object>> OrderByexpression)
        {
            OrderBy = OrderByexpression;
            return this;
        }

        public BaseSpecification<T> AddOrderByDecending(Expression<Func<T, object>> OrderByDecending)
        {
            OrderByDescending = OrderByDecending;
            return this;
        }

        public BaseSpecification<T> ApplyPaging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            isPagingEnabled = true;
            return this;
        }
    }
}