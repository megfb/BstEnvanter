using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.Entity.Concrete
{
    public class Personel : IEntity
    {

        string _name;
        string _surName;
        string _eMail;

        public int id { get; set; }
        [Required(ErrorMessage = "Ad boş olamaz")]
        public string name
        {
            get
            {
                if (_name != null)
                {
                    return _name = char.ToUpper(_name.First()) + _name.Substring(1).ToLower();
                }
                else
                {
                    return _name;
                }
            }
            set { _name = value.ToUpper(); }
        }
        [Required(ErrorMessage = "Soyad boş olamaz")]

        public string surname
        {
            get
            {
                if (_name != null)
                {
                    return _surName = char.ToUpper(_surName.First()) + _surName.Substring(1).ToLower();
                }
                else
                {
                    return _surName;
                }
            }
            set { _surName = value.ToUpper(); }
        }
        [Required(ErrorMessage = "Yaş boş olamaz")]
        public int age { get; set; }
        public Sex Sex { get; set; }
        public int ?sexId { get; set; }
        public Department Department { get; set; }
        public int? departmentId { get; set; }
        public CLocation CLocation { get; set; }
        public int? cLocationId { get; set; }
        [Required(ErrorMessage = "E-Mail boş olamaz")]

        public string eMail
        {
            get
            {
                if (_name != null)
                {
                    return _eMail = char.ToUpper(_eMail.First()) + _eMail.Substring(1).ToLower();
                }
                else
                {
                    return _eMail;
                }
            }
            set { _eMail = value.ToUpper(); }
        }
        public ICollection<Status> status { get; set; }
    }
}