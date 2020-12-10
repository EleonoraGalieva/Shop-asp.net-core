using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BakeryShop.ViewModels
{
    public class EditPieViewModel : CreatePieViewModel
    {
        public int Id { get; set; }
        public string ExistingImageFilePath { get; set; }
    }
}
