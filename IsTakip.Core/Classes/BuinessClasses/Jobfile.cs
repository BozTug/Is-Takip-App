using IsTakip.Core.Classes.BaseClass;

namespace IsTakip.Core.Classes.BuinessClasses
{
    public class Jobfile : BaseEntity
    {



        public string JobfileName { get; set; }

        public int BusinessId { get; set; }

        public Business Business { get; set; }
    }
}
