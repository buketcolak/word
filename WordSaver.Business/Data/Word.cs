using System;

namespace WordSaver.Business.Data
{
    public class Word : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class BaseEntity
    {
    }
}