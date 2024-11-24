using WebApplication7.dto;

namespace WebApplication7.repo
{
    public interface Iceinma
    {
        IList<cinamdto>getAll();
        void update(cinamdto ccinamdto,int id);
        void add(cinamdto ccinamdto);

        void delete(int id);
    }
}
