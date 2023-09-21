using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace actorLib
{

    public class ActorRepository : IActorReposetry
    {
        private int _nextId = 0;
        public List<Actor> Actors { get; set; }


        public ActorRepository() 
        {
            Actors = new List<Actor>();
        }

        public Actor Add(Actor actor)
        {
            actor.Validate();
            actor.Id = _nextId;
            ++_nextId;
            Actors.Add(actor);
            return actor;
        }
        public Actor? GetByID(int id) 
        {
            return Actors.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Actor> Get(string? orderby = null)
        {
            IEnumerable<Actor> list = Actors;
            
            if (orderby != null)
            {
                switch (orderby.ToLower())
                {
                    case "name":
                        list = list.OrderBy(t => t.Name); 
                        break;
                    case "name_desc":
                        list = list.OrderByDescending(t => t.Name);
                        break;
                    case "year":
                        list = list.OrderBy(t => t.YearOfBirth);
                        break;
                    case "year_desc":
                        list = list.OrderByDescending(t => t.YearOfBirth);
                        break;
                    default:
                        list = list.OrderBy(t => t.Id);
                        break;

                }
            }
            return list;
        }

        public List<Actor> GetAll()
        {
            return Actors;
        }

        public Actor? Remove(int id)
        {
            Actor? removedActor = Actors.FirstOrDefault(t => t.Id == id);
            if (removedActor == null) { return null; }
            Actors.Remove(removedActor);
            return removedActor;
        }
        public Actor? Update(int id, Actor actor)
        {
            Actor? TempActor = Actors.FirstOrDefault(t => t.Id == id);
            if (TempActor == null) { return null; }
            int tempId = Actors.IndexOf(TempActor);
            Actors.Insert(tempId, actor);
            return actor;
        }

        public List<string> ListOfNames()
        {
            return Actors.Select(t => t.Name).ToList();
        }

        public List<Actor> SortByName()
        {
            var list = Actors.OrderBy(actor => actor.Name);
            return list.ToList();
        }
    }
}
