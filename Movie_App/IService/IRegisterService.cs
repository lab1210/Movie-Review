using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie_App.Models;


namespace Movie_App.IService
{
    public interface IRegisterService
    {
        Registers AddUser(Registers register);
        IEnumerable<Registers> AdminList();

    }
}
