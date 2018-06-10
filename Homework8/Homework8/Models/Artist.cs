namespace Homework8.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Artist")]
    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            Artworks = new HashSet<Artwork>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArtistID { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(128)]
        public string City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
