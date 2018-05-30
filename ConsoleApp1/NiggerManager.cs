using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace NiggerSimulator
{
    class NiggerManager
    {
        private Nigger[] _niggers;
        public Nigger[] niggers
        {
            get
            {
                return _niggers;
            }
        }

        private float SocialSecurity = float.MaxValue;

        private NiggerManager()
        {

        }

        private static NiggerManager instance = new NiggerManager();

        public static NiggerManager _
        {
            get
            {
                return instance;
            }
        }
        /// <summary>
        /// Issues a FreeMoney(tm) welfare check to a nigger
        /// </summary>
        /// <returns></returns>
        public float IssueWelfareCheck(Nigger nigger)
        {
            SocialSecurity = SocialSecurity - 500;
            return 500;
        }

        /// <summary>
        /// Runs the nigger simulator
        /// </summary>
        /// <param name="NumberOfNiggers">defaults to 1 if 0.</param>
        /// <param name="AutoRespawn">a new nigger will be created for each dead nigger.</param>
        public void RunSimulation(int NumberOfNiggers, bool AutoRespawn = false)
        {
            _niggers = new Nigger[NumberOfNiggers > 0 ? NumberOfNiggers : 1];
            for(int index = 0; index < _niggers.Length; index++)
            {
                _niggers[index] = new Nigger();
            }
            
        }
    }
}
