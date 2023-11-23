namespace CRUD_EF_CORE.Entities
{
    public class Course : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Fees { get; set; }
        public bool IsActive { get; set; }
        public DateTime ClassStartDate { get; set; }
    }
}
