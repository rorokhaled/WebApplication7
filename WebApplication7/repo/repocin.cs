using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.dto;
using WebApplication7.modle;

namespace WebApplication7.repo
{



    public class repocin : Iceinma
    {
        private readonly Appdbcontext _appdbcontext;
        public repocin(Appdbcontext appdbcontext)
        {
            _appdbcontext = appdbcontext;
        }

        public void add(cinamdto ccinamdto)
        {
            var u = new cinema
            {
                name = ccinamdto.name,
                movies = ccinamdto.movies.Select(x => new movie
                {
                    title= x.title,
                    categ=new categ
                    {
                        name=x.categ.name,
                    }

                }).ToList(),

            };
            _appdbcontext.Add(u);
            _appdbcontext.SaveChanges();
        }

        public void delete(int id)
        {
         var u=_appdbcontext.cinema.FirstOrDefault(x => x.id == id);
            if (u != null) {
            
            _appdbcontext.Remove(u);
                _appdbcontext.SaveChanges();
            
            }
        }

        public IList<cinamdto> getAll()
        {
            var u = _appdbcontext.cinema.Include(x => x.movies).ThenInclude(x => x.categ).Select(y => new cinamdto
            {
                name = y.name,
                movies = y.movies.Select(o => new movie
                {
                    title = o.title,
                categ=new categ
                {
                    name=o.categ.name,
                },
                
                    

                }).ToList(),


            }).ToList();
            return u;
        }

        public void update(cinamdto ccinamdto,int id)
        {
            var u = _appdbcontext.cinema.Include(x => x.movies).ThenInclude(y => y.categ).FirstOrDefault(x => x.id == id);
            if (u != null)
            {
                u.name= ccinamdto.name;
                u.movies=ccinamdto.movies.Select(r=>new movie
                {
                    categ=new categ
                    {
                        name=r.categ.name,
                    }

                }).ToList();
                _appdbcontext.Update(u);
                _appdbcontext.SaveChanges();



            }
            

        }
    }
}
