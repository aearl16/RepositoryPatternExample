namespace Homework8.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Artwork")]
    public partial class Artwork
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artwork()
        {
            Classifications = new HashSet<Classification>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArtworkID { get; set; }

        public int ArtistID { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        public virtual Artist Artist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classification> Classifications { get; set; }
    }
}
