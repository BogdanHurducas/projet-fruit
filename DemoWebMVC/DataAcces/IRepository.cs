using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebMVC.DataAcces
{
    interface IRepository<T>
    {
        T Ajouter(T ouveau);
        T Modifier(T objetAModifier);
        void suprimer(int id);
        ICollection<T> Lister();
        T Trouver(int id);

    }
}
