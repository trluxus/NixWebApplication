using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NixWebApplication.WEB.Models.ManageViewModels
{
    public class DisplayRecoveryCodesViewModel
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }

    }
}
