using Autofac;
using CRUD_EF_CORE.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using NuGet.Protocol.Core.Types;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CRUD_EF_CORE.Models
{
    public class CourseCreateModel
    {
        public Course Course { get; set; }
        private  CourseRepository _courseRepository;
        public CourseCreateModel()
        {
            
        }
        public CourseCreateModel(CourseRepository courseRepository)
        {

            _courseRepository = courseRepository;

        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _courseRepository = scope.Resolve<CourseRepository>();
        }
      
        internal void CreateCourse()
        {
            if (!string.IsNullOrWhiteSpace(Course.Title)
                && Course.Fees >= 0)
            {
               _courseRepository.Add(Course);
            }
        }
    }
}
