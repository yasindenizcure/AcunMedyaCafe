using System.ComponentModel.DataAnnotations;

namespace AcunMedyaCafe.Entities
{
    public class Subscriber
    {
        public int SubscriberId { get; set; }

        [Required(ErrorMessage = "E-posta alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
    }
}
