using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationUploadForm.Repository
{
    [Table("upload_form")]
    public class FormUploadEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }

        [Column("image_url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Image Have Not Uploaded Yet")]
        [Display(Name = "Image")]
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
