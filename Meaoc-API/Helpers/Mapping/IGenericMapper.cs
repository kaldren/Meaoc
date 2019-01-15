namespace Meaoc_API.Helpers.Mapping
{
    public interface IGenericMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}