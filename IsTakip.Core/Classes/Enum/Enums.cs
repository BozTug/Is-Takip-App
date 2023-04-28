namespace IsTakip.Core.Classes.Enum
{
    public class Enums
    {
        public enum OfferType { WithOffer, WithoutOffer }

        public enum BusinessPriority { Low, High, Middle }

        public enum EndNoticeSituation { Yes, No }

        public enum Restriction { Yes, No }

        public enum ProductionSituation { Notstarted, Production, Completed }

        public enum MailNotification { Yes, No }
        public enum Workmanship { Yes, No }

        public enum MaterialType
        {
            Wood,
            Metal,
            Plastic,
            Glass,
            Ceramic,
            Stone,
            Fabric,
            Leather,
            Composite,
            Paper,
            Other
        }
        public enum Thickness
        {
            Thin,
            Medium,
            Thick,
            VeryThick
        }
        public enum ProductionOrder
        {
            Done,
            NotYet
        }
        public enum ProductionLeadType
        {
            ProductionNotStarted,
            ProductionInProgress,
            ProductionCompleted
        }
        public enum RoleDescription
        {
            Admin,
            Manager,
            HumanResources,
            Sales,
            Marketing,
            Accountant,
            IT,
            CustomerService,
            Operations,
            TechnicalSupport,
            Warehouse,
            Security
        }


    }


}
