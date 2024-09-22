using BstEnvanter.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BstEnvanter.Entity.Concrete
{
    public class Service:IEntity
    {
        string _company;
        string _specialist;
        string _adress;
        string _issue;
        public int id { get; set; }
        public int processNumber { get; set; }
        [Required(ErrorMessage = "Kurum adı boş olamaz")]

        public string company
        {
            get
            {
                if (_company != null)
                {
                    return _company = char.ToUpper(_company.First()) + _company.Substring(1).ToLower();
                }
                else
                {
                    return _company;
                }
            }
            set { _company = value.ToUpper(); }
        }
        [Required(ErrorMessage = "Uzman adı boş olamaz")]

        public string specialist
        {
            get
            {
                if (_company != null)
                {
                    return _specialist = char.ToUpper(_specialist.First()) + _specialist.Substring(1).ToLower();
                }
                else
                {
                    return _specialist;
                }
            }
            set { _specialist = value.ToUpper(); }
        }
        [Required(ErrorMessage = "Numara boş olamaz")]

        public Int64 number { get; set; }
        [Required(ErrorMessage = "Adres boş olamaz")]

        public string adress
        {
            get
            {
                if (_company != null)
                {
                    return _adress = char.ToUpper(_adress.First()) + _adress.Substring(1).ToLower();
                }
                else
                {
                    return _adress;
                }
            }
            set { _adress = value.ToUpper(); }
        }
        [Required(ErrorMessage = "Sorun boş olamaz")]

        public string issue
        {
            get
            {
                if (_company != null)
                {
                    return _issue = char.ToUpper(_issue.First()) + _issue.Substring(1).ToLower();
                }
                else
                {
                    return _issue;
                }
            }
            set { _issue = value.ToUpper(); }
        }
        public DateTime dateOfStart { get; set; }
        public DateTime dateOfEnd { get; set; }
        public ICollection<Status> status { get; set; }
    }
}
