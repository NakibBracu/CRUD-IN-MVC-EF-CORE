using Autofac;
using CRUD_EF_CORE.Models;

namespace CRUD_EF_CORE
{
    public class WebModule : Module
    {


        public WebModule()
        {
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseCreateModel>().AsSelf();
            builder.RegisterType<CourseRepository>().AsSelf();
        }
    }
}
