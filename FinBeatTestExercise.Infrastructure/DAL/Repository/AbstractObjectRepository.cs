using FinBeatTestExercise.Application.Contracts;
using FinBeatTestExercise.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace FinBeatTestExercise.Infrastructure.DAL.Repository;

public class AbstractObjectRepository(
    FinBeatDbContext dbContext) : IAbstractObjectRepository
{
    public async Task AddAbstractObjectAsync(AbstractObject value)
    {
        await dbContext.AbstractObjects.AddAsync(value);

        await dbContext.SaveChangesAsync();
    }

    public async Task AddAbstractObjectsAsync(IReadOnlyCollection<AbstractObject> values)
    {
        await dbContext.AbstractObjects.AddRangeAsync(values);

        await dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<AbstractObject>> GetObjectsByFilterAsync(Dictionary<string, string> filters)
    {
        var dataSet = dbContext.AbstractObjects.AsQueryable();

        foreach (var filter in filters)
        {
            var entityType = typeof(AbstractObject);

            var propertyInfo = entityType.GetProperty(filter.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (propertyInfo != null)
            {
                object? filterValue = Convert.ChangeType(filter.Value, propertyInfo.PropertyType);

                string query = $"{filter.Key} == @0";

                dataSet = dataSet.Where(query, filterValue);
            }
        }

        return await dataSet.ToListAsync();
    }

    public async Task RemoveAllObjectsAsync()
    {
        var allObjects = await dbContext.AbstractObjects.AsNoTracking().ToListAsync();

        dbContext.AbstractObjects.RemoveRange(allObjects);

        await dbContext.SaveChangesAsync();
    }
}
