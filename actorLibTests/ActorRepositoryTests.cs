using Microsoft.VisualStudio.TestTools.UnitTesting;
using actorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actorLib.Tests
{
    [TestClass()]
    public class ActorRepositoryTests
    {
        [TestMethod()]
        public void AddTest()
        {
            ActorRepository repository = new ActorRepository();
            Actor actor1 = new Actor("tom hangs",2000,Genre.drama);
            var repLenght = repository.Actors.Count();
            repository.Add(actor1);
            Assert.AreEqual(repLenght + 1, repository.Actors.Count());
        }

        [TestMethod()]
        public void ListReturnTest()
        {
            ActorRepository repository = new ActorRepository();
            Actor actor1 = new Actor("tom hangs", 2000, Genre.drama);
            Actor actor2 = new Actor("tom cruse", 2000, Genre.action);
            repository.Add(actor1);
            repository.Add(actor2);
            var getAll = repository.GetAll();
            Assert.IsInstanceOfType(getAll, typeof(List<Actor>));
        }

        [TestMethod()]
        public void Remove()
        {
            ActorRepository repository = new ActorRepository();
            Actor actor1 = new Actor("tom hangs", 2000, Genre.drama);
            Actor actor2 = new Actor("tom cruse", 2000, Genre.action);
            Actor actor3 = new Actor("tom ruddle", 2005, Genre.codedy);
            repository.Add(actor1);
            repository.Add(actor2);
            repository.Add(actor3);

            Assert.AreEqual(repository.Actors.Count(), 3);
            repository.Remove(0);
            Assert.AreEqual(repository.Actors.Count(), 2);
        }

        [TestMethod()]
        public void Update()
        {
            ActorRepository repository = new ActorRepository();
            Actor actor1 = new Actor("tom hangs", 2000, Genre.drama);
            Actor actor2 = new Actor("tom cruse", 2000, Genre.action);
            Actor actor3 = new Actor("tom ruddle", 2005, Genre.codedy);
            repository.Add(actor1);
            repository.Add(actor2);
            var list1 = repository.Actors[0];
            repository.Update(0, actor3);
            var list2 = repository.Actors[0];
            Assert.AreNotEqual(list1, list2);
        }

        [TestMethod()]
        public void GetbyId()
        {
            ActorRepository repository = new ActorRepository();
            Actor actor1 = new Actor("tom hangs", 2000, Genre.drama);
            Actor actor2 = new Actor("tom cruse", 2000, Genre.action);
            repository.Add(actor1);
            repository.Add(actor2);

            var item1 = repository.GetByID(1);

            Assert.AreEqual(item1, repository.Actors[1]);
        }
        public void GetbyIdUotOfRange()
        {
            ActorRepository repository = new ActorRepository();
            Actor actor1 = new Actor("tom hangs", 2000, Genre.drama);
            Actor actor2 = new Actor("tom cruse", 2000, Genre.action);
            repository.Add(actor1);
            repository.Add(actor2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.GetByID(5));
        }
        public void GetbyIdUotOfRangenegative()
        {
            ActorRepository repository = new ActorRepository();
            Actor actor1 = new Actor("tom hangs", 2000, Genre.drama);
            Actor actor2 = new Actor("tom cruse", 2000, Genre.action);
            repository.Add(actor1);
            repository.Add(actor2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.GetByID(-1));
        }
    }
}