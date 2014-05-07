using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiledProblems
{
    public abstract class BaseProblem : IProblem
    {
        protected readonly int id;
        protected readonly string title;
        protected readonly string description;

        protected string[] parametersInfo;
        protected string[] defaultParameters;

        protected BaseProblem(int id, string title, string description, string[] parametersInfo, string[] defaultParameters)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.parametersInfo = parametersInfo;
            this.defaultParameters = defaultParameters;
        }

        public int GetID()
        {
            return id;
        }

        public string GetTitle()
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(title));
        }

        public string GetDescription()
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(description));
        }

        public string[] GetParametersInfo()
        {
            return parametersInfo;
        }

        public string[] GetDefaultParameters()
        {
            return defaultParameters;
        }

        public abstract string Solve(string[] parameters);
    }
}
