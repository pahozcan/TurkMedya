using System.Collections.Generic;

namespace TurkMedya.Models
{
    public class DetayViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string BodyText { get; set; }
        public bool HasPhotoGallery { get; set; }
        public bool HasVideo { get; set; }
        public string PublishDate { get; set; }
        public string FullPath { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public string RelatedNewsShortText { get; set; }
    }
}
