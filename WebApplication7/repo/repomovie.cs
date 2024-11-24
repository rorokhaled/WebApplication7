using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.dto;
using WebApplication7.modle;

namespace WebApplication7.repo
{
    public class repomovie : Imovie
    {
        private readonly  Appdbcontext _dbcontext;
        public repomovie(Appdbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
    
        public void add(moviedto moviedto)
        {
            var u = new movie
            {
                title = moviedto.title,
                categ = new categ
                {
                  name=moviedto.categ.name,
                },
                cinema=new cinema
                {
                    name=moviedto.cinema.name,
                }
            };
            _dbcontext.Add(u);
            _dbcontext.SaveChanges();
        }

        public moviedto getbyid(int id)
        {
           var u=_dbcontext.movies.Include(x=>x.cinema).Include(x=>x.categ).FirstOrDefault(x=>x.id==id);

            return new moviedto

            {
                title = u.title,
                categ = new categ
                {
                    name = u.categ.name,
                },
                cinema = new cinema
                {
                    name = u.cinema.name,
                }
            };

            

        }

        public IList< moviedto> GettAll()
        {
            var u = _dbcontext.movies.Include(x => x.cinema).Include(x => x.categ).Select(x => new moviedto
            {
                title = x.title,
                cinema = new cinema
                {
                    name = x.cinema.name,

                },
                categ = new categ
                {
                    name = x.categ.name,
                }


            }




                ).ToList();
            return u;
         



        }

      
    }
}
