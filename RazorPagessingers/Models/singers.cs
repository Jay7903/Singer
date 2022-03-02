using System.ComponentModel.DataAnnotations;

namespace RazorPagessingers.Models
{
    public class singers
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string PopularAlbum { get; set; } = string.Empty;
        public decimal NumberOfAwards { get; set; }
    }
}