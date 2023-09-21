using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actorLib
{
    public interface IActorReposetry
    {
        Actor Add(Actor actor);
        IEnumerable<Actor> Get(string? name = null, int? price = null, string? genre = null);
        Actor? GetById();
        Actor? Remove();
        Actor? Update();
    }
}
