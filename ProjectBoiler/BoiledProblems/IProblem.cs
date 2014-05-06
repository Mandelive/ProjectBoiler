using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiledProblems
{
    public interface IProblem
    {
        int GetID();
        string GetDescription();
        string[] GetParametersInfo();
        string[] GetDefaultParameters();
        string Solve(string[] parameters);
    }
}
