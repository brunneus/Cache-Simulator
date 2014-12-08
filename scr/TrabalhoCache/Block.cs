using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoCache
{
    public class Block
    {
        #region Attributes and Properties

        //Rótulo do bloco
        public string Tag { get; set; }

        //Palavra do bloco
        public string OffSet { get; set; }

        //Bit de atualização do bloco
        public int DirtyBit { get; set; }

        //Controle da "idade" do bloco
        public int LRUControl { get; set; }

        #endregion
    }
}
