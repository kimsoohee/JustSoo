using System;

namespace www.Models.Entities
{
    public class BoardEntity: BaseEntity
    {
        public int rownum { get; set; }
        public int board_seq { get; set; }
        public string board_type { get; set; }
        public string board_type_code { get; set; }
        public string subject { get; set; }        
        public string contents { get; set; }
        public int view_count { get; set; }
        public int user_seq { get; set; }
        public DateTime reg_date { get; set; }
    }
}