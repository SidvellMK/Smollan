using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWebApp.Models.ViewModels
{
    public class RoleEditorViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
