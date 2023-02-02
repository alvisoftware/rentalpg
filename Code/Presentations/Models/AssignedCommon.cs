    using static DomainLayer.Models.PropertyInfo;

namespace Presentations.Models
{
    public class AssignedCommon
    {
        public long tenantid { get; set; }
        public long propertyid { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public transtype transtpetype { get; set; }//0 = sale / 1= etle rent
        public enum transtype
        {
            Sale = 0,
            Rent = 1
        }
        public payas amount { get; set; }
        public enum payas
        {
            Fix=0,
            Weekly=1
        }
    }
}
