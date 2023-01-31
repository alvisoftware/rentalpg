namespace Frontend.Models
{
    public class ResponseModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string badroom { get; set; }
        public string bathroom { get; set; }
        public double area { get; set; }
        public string image { get; set; }
        public DateTime availabledate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string seurl { get; set; }
    }
}
