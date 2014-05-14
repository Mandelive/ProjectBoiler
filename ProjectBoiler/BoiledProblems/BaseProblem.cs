using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiledProblems
{
    public abstract class BaseProblem : IProblem
    {
        protected int id;
        protected string title;
        protected string description;

        protected string[] parametersInfo;
        protected string[] defaultParameters;

        protected string[] parameters;

        public int Id
        { 
            get { return id; }
            protected set { id = value; }
        }

        public string Title
        {
            get { return Encoding.UTF8.GetString(Convert.FromBase64String(title)); }
            protected set { title = value; }
        }

        public string Description
        {
            get { return Encoding.UTF8.GetString(Convert.FromBase64String(description)); }
            protected set { description = value; }
        }

        public int ParametersCount
        {
            get { return defaultParameters.Length; }
        }
        
        public string[] GetParametersInfo()
        {
            var copyParametersInfo = new string[parametersInfo.Length];
            parametersInfo.CopyTo(copyParametersInfo, 0);
            return copyParametersInfo;
        }

        public string[] GetDefaultParameters()
        {
            var copyDefaultParameters = new string[defaultParameters.Length];
            defaultParameters.CopyTo(copyDefaultParameters, 0);
            return copyDefaultParameters;
        }

        public string[] GetParameters()
        {
            var copyParameters = new string[parameters.Length];
            parameters.CopyTo(copyParameters, 0);
            return copyParameters;
        }

        public void ResetParameters()
        {
            parameters = new string[defaultParameters.Length];
            defaultParameters.CopyTo(parameters, 0);
        }

        public void SetParameters(string[] parameters)
        {
            if (parameters.Length != defaultParameters.Length)
            {
                throw new ArgumentException("Invalid parameters");
            }

            try
            {
                for (int i = 0; i < defaultParameters.Length; i++)
                {
                    var parameterType = parametersInfo[i].Substring(2, 3);
                    switch (parameterType)
                    {
                        case "num":
                            var num = Int64.Parse(parameters[i]);
                            this.parameters[i] = num.ToString();
                            break;
                        case "str":
                            this.parameters[i] = parameters[i];
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid parameters: " + e.Message);
            }
        }

        public abstract string Solve();
    }
}
