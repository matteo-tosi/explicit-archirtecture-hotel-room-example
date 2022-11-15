using System.Linq.Expressions;
using System.Reflection;

namespace DotNetExtensions.LambdaExpression.Converter
{
    public class ExpressionConverter<TSource, TOut> : ExpressionVisitor
        where TSource : class
        where TOut : class
    {
        public Expression ConvertPredicate(Expression expr) => this.Visit(expr);

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            return typeof(T) == typeof(Func<TSource, bool>)
                ? Expression.Lambda<Func<TOut, bool>>(this.Visit(node.Body), GetReplacedParameterExpression())
                : base.VisitLambda(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
            => node.Type == typeof(TSource) ? GetReplacedParameterExpression() : base.VisitParameter(node);

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TSource))
            {
                var member = typeof(TOut)
                    .GetMember(node.Member.Name, BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault();

                return member == null
                    ? throw new InvalidOperationException($"Cannot identify corresponding member of {nameof(TOut)}")
                    : (Expression)Expression.MakeMemberAccess(this.Visit(node.Expression), member);
            }
            return base.VisitMember(node);
        }

        private static ParameterExpression GetReplacedParameterExpression()
            => Expression.Parameter(typeof(TOut), name: "p");
    }
}
