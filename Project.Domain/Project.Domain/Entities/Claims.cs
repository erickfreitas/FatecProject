using System;

namespace Project.Domain.Entities
{
    public class Claims
    {
        public Claims()
        {
            ClaimsId = Guid.NewGuid();
        }

        public Guid ClaimsId { get; set; }

        public string Nome { get; set; }
    }
}
