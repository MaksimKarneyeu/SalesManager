using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManager.Data.Entities
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
    }
}