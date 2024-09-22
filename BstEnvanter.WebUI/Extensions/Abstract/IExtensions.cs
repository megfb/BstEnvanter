using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Extensions.Abstract
{
    public interface IExtensions
    {
        public List<Status> GetAll(string name, int id);
    }
}
