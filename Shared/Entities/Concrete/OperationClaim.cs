using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}