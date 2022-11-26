using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Resources
{
    public class BaseResource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان تعیین نشده.")]
        [StringLength(255, ErrorMessage = "عنوان حداکثر ۲۵۵ کاراکتر.")]
        [DisplayName("عنوان")]
        public string Name { get; set; }
    }
}
