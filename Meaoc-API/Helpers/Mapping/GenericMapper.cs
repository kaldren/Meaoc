using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meaoc_API.Helpers.Mapping
{
    public class GenericMapper<TSource, TDestination> : IGenericMapper<TSource, TDestination>
    {
        private readonly IMapper _mapper;

        public GenericMapper(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public TDestination Map(TSource source)
        {
            var mappedObject = _mapper.Map<TDestination>(source);

            return mappedObject;
        }
    }
}
