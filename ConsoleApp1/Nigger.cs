using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace NiggerSimulator
{
    class Nigger
    {
        /// <summary>
        /// Traditional nigger drugs
        /// </summary>
        public enum NiggerDrugs
        {
            Crack,
            Sherm
        }

        /// <summary>
        /// Traditional nigger names
        /// </summary>
        public enum NiggerNames
        {
            DeShawn, DeAndre,
            Marquis, Darnell,
            Terrell, Malik,
            Trevon, Tyrone,
            Willie, Dominique,
            Demetrius, Reginald,
            Jamal, Maurice,
            Jalen, Darius,
            Xavier, Terrance,    
            Andre, Darryl
        }
        public NiggerNames name;
        public float worth = -300; // most niggers start off with their parent's debt
        public float health = 100; // this is debatable 

        /// <summary>
        /// Assign a random nigger name to the nigger 
        /// </summary>
        protected void AssignNiggerName()
        {
            var lnames = Enum.GetValues(typeof(NiggerNames));
            name = (NiggerNames)lnames.GetValue(new Random().Next(lnames.Length));
        }

        /// <summary>
        /// Selects a random nigger drug from the list of available nigger drugs
        /// </summary>
        /// <returns></returns>
        protected NiggerDrugs GetRandomNiggerDrug()
        {
            var lnames = Enum.GetValues(typeof(NiggerDrugs));
            return (NiggerDrugs)lnames.GetValue(new Random().Next(lnames.Length));
        }

        /// <summary>
        /// Select a random nigger function from the Nigger class (filtered by the NiggerFunction attribute) and invoke it
        /// </summary>
        protected void PerformRandomNiggerFunction()
        {
            var niggerfuncs = this.GetType()
                       .GetMethods()
                       .Where(w => w.GetCustomAttributes().Any(a => a.GetType() == typeof(NiggerFunction)))
                       .ToArray();
            niggerfuncs[new Random().Next(niggerfuncs.Length)].Invoke(this, new object[] { BindingFlags.InvokeMethod });
        }
        
       
        /// <summary>
        /// Initialize a new nigger
        /// </summary>
        public Nigger()
        {
            AssignNiggerName();
            Debug.WriteLine(string.Format("{0} has been initialized", name.ToString()));
        }

        /// <summary>
        /// Drive this nigger slave to it's inevitible death, to be invoked externally by the NiggerManager class
        /// </summary>
        public void Drive()
        {
            while (health > 0)
            {
                try
                {
                    PerformRandomNiggerFunction();
                }
                catch (NotImplementedException ex)
                {
                    // sometimes niggers are called upon to do tasks that they're not capable of, such as work and find a job, 
                    // we need to make sure we handle these cases and log them. It's unfortunate that it has to be implemented as an exception, 
                    // but that is the burden that must carried (overhead) for the sake of the accuracy of this simulation:
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Busts a cap in another niggers ass
        /// </summary>
        [NiggerFunction]
        public void ShootOtherNigger()
        {
            var niggerone = this;
            var niggertwo = NiggerManager._.niggers[new Random().Next(NiggerManager._.niggers.Length)];

            Debug.WriteLine(string.Format("{0} shot {1}", new object[] { niggerone, niggertwo }));

            niggertwo.health = niggertwo.health - 10;
            Debug.WriteLine(string.Format("{0} health is at {1}", new object[] { niggertwo.name, niggertwo.health }));
        }

        /// <summary>
        /// No need for this one either
        /// </summary>
        [NiggerFunction]
        public void DoWork()
        {
            throw new NotImplementedException(string.Format("{0} was told by the man to do with but niggers don't do work", this.name));
        }

        /// <summary>
        /// Probably gonna leave this unimplemented since niggers can easily obtain welfare checks from the government for free
        /// </summary>
        [NiggerFunction]
        public void FindJob()
        {
            throw new NotImplementedException(string.Format("{0} was told by the man to get a job but niggers don't need jobs", this.name));
        }

        /// <summary>
        /// Collects a FreeMoney(tm) check from the Social Security office
        /// </summary>
        [NiggerFunction]
        public void CollectWelfareCheck()
        {
            worth = (worth >= 0) ? worth + NiggerManager._.IssueWelfareCheck(this) : worth - NiggerManager._.IssueWelfareCheck(this);
            Debug.WriteLine(string.Format("{0} shiieet just got me a motha fuckin welfare check!", this.name));
            Debug.WriteLine(string.Format("{0} new nigger balance: {1}", new object[] { this.name, this.worth }));
        }

        /// <summary>
        /// Sells drugs to another nigger, typically crack coaine or PCP
        /// </summary>
        [NiggerFunction]
        public void SellNiggerDrugsToAnotherNigger()
        {
            var niggerone = this;
            var niggertwo = NiggerManager._.niggers[new Random().Next(NiggerManager._.niggers.Length)];
            var drug = GetRandomNiggerDrug();
            Debug.WriteLine(string.Format("{0} sold {1} to {2}", new object[] { niggerone, drug.ToString(), niggertwo }));

            niggertwo.worth = niggertwo.worth - 100;
            Debug.WriteLine(string.Format("{0} remaining nigger balance: is at {1}", new object[] { niggertwo.name, niggertwo.worth }));
        }
    }
    /// <summary>
    /// Used to denote the common functions of niggers within the nigger class
    /// </summary>
    public class NiggerFunction : Attribute { }

}


