using API.AutomapperModule;
using AutoMapper;

namespace API.App_Start
{
    public static class AutomapperConfig
    {
        public static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MovieProfile>();
            });

            return config;
        }
    }
}