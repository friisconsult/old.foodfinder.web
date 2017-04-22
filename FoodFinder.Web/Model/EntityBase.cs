using System;

namespace FoodFinder.Web.Model
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public EntityBase()
        {
            Created = DateTime.UtcNow;

            Updated = DateTime.UtcNow;
        }
    }
}