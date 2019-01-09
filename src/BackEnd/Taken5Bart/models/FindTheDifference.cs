using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FindTheDifference
    {
        public int Id { get; set; }
        public ICollection<FindTheDifferenceItem> FoundItemsList { get; set; }

        public int ItemsFoundCount { get {
                var result = 0;
                foreach(FindTheDifferenceItem i in FoundItemsList)
                {
                    if (i.found)
                        result++;
                }
                return result;
            } }

        public int AssignedTeamId { get; set; }
    }

    public class FindTheDifferenceItem
    {
        public int Id { get; set; }
        public bool found { get; set; }
    }
}
