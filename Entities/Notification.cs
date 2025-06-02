namespace AcunMedyaCafe.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }= DateTime.Now;
    }
}
