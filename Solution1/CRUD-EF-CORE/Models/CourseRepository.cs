using CRUD_EF_CORE.Entities;

namespace CRUD_EF_CORE.Models
{
    public class CourseRepository : Repository<Course, int>
    {
        //This class will handle the persistency

        public CourseRepository(TrainingDbContext context) : base(context)
        {
        }

    }
}
