using System.Linq.Expressions;

namespace KingFisher.Infrastructure.EFCore.DbContexts.SQLServer;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "<Pending>")]
public static class QueryableExtensions
{
	public static IQueryable<TEntity> UseSelector<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, TEntity>> selector)
	{
		return selector is not null ? queryable.Select(selector) : queryable;
	}

	//https://github.com/dotnet/efcore/issues/13617
	public static IQueryable<TQuery> WhereIn<TKey, TQuery>(this IQueryable<TQuery> queryable,
			Expression<Func<TQuery, TKey>> keySelector, IEnumerable<TKey> values)
	{
		TKey[] distinctValues = values.Distinct().ToArray();

		int count = distinctValues.Length;
		var body = distinctValues
				.Select(v =>
				{
					// Create an expression that captures the variable so EF can turn this into a parameterized SQL query
					Expression<Func<TKey>> valueAsExpression = () => v;
					return Expression.Equal(keySelector.Body, valueAsExpression.Body);
				})
				.Aggregate(Expression.OrElse);

		var whereClause = Expression.Lambda<Func<TQuery, bool>>(body, keySelector.Parameters);

		return queryable.Where(whereClause);
	}
}
