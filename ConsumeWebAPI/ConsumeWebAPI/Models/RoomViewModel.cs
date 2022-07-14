using ConsumeWebAPI.Data;

namespace ConsumeWebAPI.Models
{
    public class RoomViewModel
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public RoomType RoomType { get; set; }
        public bool Avilable { get; set; }
        public RoomStatus Status { get; set; }
        public int CoustomerCount { get; set; }
        public bool CanBookingmore { get; set; }
        public int BranchId { get; set; }




        //    public virtual List<Booking>? Bokings { get; set; }
        //    [JsonIgnore]
        //    public virtual Branch? Branch { get; set; }
    }
}
