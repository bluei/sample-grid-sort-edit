using System.ComponentModel.DataAnnotations;

namespace SampleSortableChildCollectionForm.Models.Editors
{
    public class AddressEditorViewModel
    {
        // display order zero prevents the table header from generating for this property
        [Display(Order = 0)]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }
    }
}