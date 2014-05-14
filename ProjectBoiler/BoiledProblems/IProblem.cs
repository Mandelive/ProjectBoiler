using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiledProblems
{
    public interface IProblem
    {
        int Id { get; }
        string Title { get; }
        string Description { get; }

        int ParametersCount { get; }
        
        string[] GetParametersInfo();
        string[] GetDefaultParameters();
        string[] GetParameters();

        void ResetParameters();
        void SetParameters(string[] parameters);
        
        string Solve();
    }
}
