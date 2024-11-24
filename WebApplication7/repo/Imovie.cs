using WebApplication7.dto;

namespace WebApplication7.repo
{
    public interface Imovie
    {
      IList  <moviedto> GettAll();
        moviedto getbyid(int id);
        void add(moviedto moviedto);
    }
}
