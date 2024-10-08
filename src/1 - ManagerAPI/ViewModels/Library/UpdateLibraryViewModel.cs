using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.ViewModels
{
    public class UpdateLibraryViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string NameBook { get; set; }

        [Required]
        public long CodeSerial { get; set; }

        [Required]
        public bool BkExists { get; set; }
    }
}