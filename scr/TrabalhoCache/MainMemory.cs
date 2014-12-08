namespace TrabalhoCache
{
    public static class MainMemory
    {
        #region Attributes and Properties

        //Tempo de acesso na memoria principal
        public static int AccessTime { get; set; }

        //Escritas na memoria princiapal
        public static int Writes { get; set; }

        //Leituras na memoria principal
        public static int Reads { get; set; }

        #endregion
    }
}
