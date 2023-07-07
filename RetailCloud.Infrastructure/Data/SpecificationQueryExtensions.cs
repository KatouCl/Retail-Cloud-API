using System.Linq;
using Microsoft.EntityFrameworkCore;
using RetailCloud.Core.Entities;
using RetailCloud.Core.Specifications.Base;

namespace RetailCloud.Infrastracture.Data
{
    public static class SpecificationQueryExtensions
    {
        public static IQueryable<T> ToQuery<T>(this ISpecifications<T> spec, IQueryable<T> inputQuery)
            where T : BaseEntity
        {
            var query = inputQuery.AsQueryable();
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.isPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}