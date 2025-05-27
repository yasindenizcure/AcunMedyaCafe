using System.ComponentModel.DataAnnotations;

namespace AcunMedyaCafe.Entities
{
    public class Subscriber
    {
        public int SubscriberId { get; set; }
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz.")]
        public string Email { get; set; }
    }
}
