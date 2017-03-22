namespace www.Models.Entities
{
    public class CodeEntity : BaseEntity
    {
        public int code_seq { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string code { get; set; }
        public string parents_code { get; set; }
    }
}