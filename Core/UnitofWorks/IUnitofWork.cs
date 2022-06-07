using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitofWork
{
   public interface IUnitofWork
    {
        Task CommitAsync(); //SaveChancesAsync()
        void Commit(); //SaveChances();
    }
}
