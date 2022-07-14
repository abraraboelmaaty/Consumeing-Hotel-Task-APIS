namespace ConsumeWebAPI.Models
{
    public class BookingModelView
    {
        public int Id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { set; get; }
        public int RoomId { get; set; }
        public string UserId { set; get; }
        public int BranchId { get; set; }
    }
}
