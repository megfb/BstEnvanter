using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class IndexViewModel
    {
        public string DimensionOne { get; set; }
        public int Quantity { get; set; }
        public List<Status> status { get;  set; }
        public int personelCount { get;  set; }
        public int statusCount { get;  set; }
        public int commonCount { get;  set; }
        public List<Category> categories { get;  set; }
        public List<Campus> campus { get;  set; }
    }
}