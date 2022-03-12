using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutbolLigi.Models
{
    public class PuanTablosu
    {
        public int ID { get; set; }
        [Display(Name = "Takım Adı")]
        public string TakimAdi { get; set; }
        public int? Galibiyet { get; set; }
        public int? Beraberlik { get; set; }
        [Display(Name = "Mağlubiyet")]
        public int? Maglubiyet { get; set; }
        [Display(Name = "Atılan Gol")]
        public int? AtilanGol { get; set; }
        [Display(Name = "Yenilen Gol")]
        public int? YenilenGol { get; set; }

        [Display(Name = "Toplam Maç Sayısı")]
        [NotMapped]
        public int ToplamMacSayisi
        { 
           
            get
            {
                if (Galibiyet == null ||
                    Beraberlik == null ||
                    Maglubiyet == null)
                    return -1;

                int sonuc = Galibiyet.Value + Beraberlik.Value + Maglubiyet.Value;
                return sonuc;
            }
        }

        [NotMapped]
        public int Averaj
        {
            get
            {
                if (AtilanGol == null ||
                    YenilenGol == null)
                    return -1;

                int sonuc = AtilanGol.Value - YenilenGol.Value;
                return sonuc;
            }
        }
        [NotMapped]
        public int Puan
        {
            set
            {

            }
            get
            {
                if (Galibiyet == null ||
                    Beraberlik == null)
                    return -1;

                int sonuc = Galibiyet.Value * 3 + Beraberlik.Value;
                return sonuc;
            }
        }
    }
}
