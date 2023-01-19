using AutoMapper;
using Lesson26InClass.Database.Entities;
using Lesson26InClass.Models.Request;

namespace Lesson26InClass
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AsparagusIDto, Asparagus>()
                .ForMember(d => d.SendTime, o => o.MapFrom(s => DateTime.Now));
        }
    }
}
