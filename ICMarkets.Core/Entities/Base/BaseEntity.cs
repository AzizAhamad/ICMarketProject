using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMarkets.Core.Entities.Base
{
	public class BaseEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public DateTime CreatedAt { get; set; }


        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}


