using Microsoft.AspNetCore.Identity;

namespace BstEnvanter.WebUI.Identity
{
    public class ApplicationUser:IdentityUser
    {
        string _name;
        string _surname;
        string _gender;
        string _department;
        string _roomNo;
        string _title;

        public string name
        {
            get { return _name = char.ToUpper(_name.First()) + _name.Substring(1).ToLower(); }
            set { _name = value.ToUpper(); }
        }
        public string surname
        {
            get { return _surname = char.ToUpper(_surname.First()) + _surname.Substring(1).ToLower(); }
            set { _surname = value.ToUpper(); }
        }
        public int age { get; set; }
        public string gender
        {
            get { return _gender = char.ToUpper(_gender.First()) + _gender.Substring(1).ToLower(); }
            set { _gender = value.ToUpper(); }
        }
        public string department
        {
            get { return _department = char.ToUpper(_department.First()) + _department.Substring(1).ToLower(); }
            set { _department = value.ToUpper(); }
        }
        public string ?roomNo
        {
            get { return _roomNo.ToUpper(); }
            set { _roomNo = value.ToUpper(); }
        }
        public string title
        {
            get { return _title = char.ToUpper(_title.First()) + _title.Substring(1).ToLower(); }
            set { _title = value.ToUpper(); }
        }

    }
}
