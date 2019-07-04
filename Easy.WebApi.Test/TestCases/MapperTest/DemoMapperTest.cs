using AutoMapper;
using Easy.WebApi.Models;
using Easy.WebApi.Services.Models.ResponseDto;
using Xunit;

namespace Easy.WebApi.Test.TestCases.MapperTest
{
    public class DemoMapperTest
    {
        [Fact(DisplayName = "测试DemoMapper")]
        public void DemoMapping()
        {
            Mapper.Initialize(cfg =>
                cfg.CreateMap<EntityDemo, EntityDemoOutputDto>()
                    .ForMember(dest => dest.Name1, opt => opt.MapFrom(src => src.Name)));
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}