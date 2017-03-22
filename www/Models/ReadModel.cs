using System.Collections.Generic;
using www.Models.Entities;

namespace www.Models
{
    public class ReadModel
    {
        public List<BoardEntity> series_list { get; set; }
        public List<BoardEntity> latest_list { get; set; }
        public BoardEntity board { get; set; }
    }
}