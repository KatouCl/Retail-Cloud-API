namespace RetailCloud.Core.Entities.Enums
{
    public enum OrganizationType
    {
        NONE,

        /// <summary>
        /// Юр.лицо
        /// </summary>
        UL = 1,

        /// <summary>
        /// ИП, ЧП
        /// </summary>
        FL = 2,

        /// <summary>
        /// иностранная организация(кроме тамож.союз)
        /// </summary>
        FO = 3,

        /// <summary>
        /// Таможенный союз
        /// </summary>
        TS = 4
    }
}