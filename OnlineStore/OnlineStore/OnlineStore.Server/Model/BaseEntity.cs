using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Server.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
