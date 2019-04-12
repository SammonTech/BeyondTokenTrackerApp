namespace TokenTracker.Domain.Entities.Dtos
{
    public class NamelyUpdateSvm
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        //todo: Make this an ENUM
        //todo: Add departments to SQL Group Table
        public string NamelyDepartment { get; set; }
        public bool IsActive { get; set; }
    }
}
