using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Güncellenme Tarihi")]
        public DateTime LastModifiedOn { get; set; }

        [DisplayName("Silinme Durumu")]
        public bool IsDeleted { get; set; }

        [DisplayName("Aktif Durumu")]
        public bool IsActive { get; set; }
    }
}
