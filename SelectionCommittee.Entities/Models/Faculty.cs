using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SelectionCommittee.DAL.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        public int FreePlacesAmount { get; set; }

        public int TotalPlacesAmount { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string About { get; set; }

        public List<ClientProfile> Candidates { get; set; }
    }
}
