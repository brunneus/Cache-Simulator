using System.Collections.Generic;

namespace TrabalhoCache
{
    public class Set
    {
        #region Constructors

        public Set()
        {
            Blocks = new List<Block>();
        }

        #endregion

        #region Attributes and Properties

        //Armazena os blocos do conjuto.
        public List<Block> Blocks { get; set; }

        //Atualiza os controle de idade dos blocos.
        public void UpdateLru()
        {
            foreach (Block bloco in Blocks)
                bloco.LRUControl--;
        }

        //Numero de linhas por conjunto
        public int Associativity { get; set; }

        //Número do conjunto
        public int Number { get; set; }

        #endregion

        #region Public Methods

        //Verifica se o bloco está cheio
        public bool IsFull()
        {
            return Blocks.Count == Associativity;
        }

        #endregion
    }
}
