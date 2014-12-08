using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoCache
{
    public static class CacheMemoryHelper
    {
        #region Static Methods

        public static readonly int ADDRESSBITS = 32;

        //Converte bytes to bits
        public static int BytesToBit(int byteNumber)
        {
            if (byteNumber == 1)
                return byteNumber;

            if (byteNumber % 2 != 0)
                return 0;

            int bitNumber = 0;

            while (byteNumber != 1)
            {
                bitNumber++;
                byteNumber /= 2;
            }

            return bitNumber;
        }

        //Converte Hexadecimal para binário
        public static string HexaToBinary(string hexaNumber)
        {
            string binary = "";
            binary = String.Join(String.Empty, hexaNumber.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            return binary;
        }

        //Constroi o endereço de entrada
        public static Address BuildAddress(int offsetSize, int rowsNumber, int setRowsNumber, string adress)
        {
            int offSet_Size = BytesToBit(offsetSize);
            int rows_Number = BytesToBit(rowsNumber / setRowsNumber);
            int setRows_Number = ADDRESSBITS - (offSet_Size + rows_Number);

            adress = HexaToBinary(adress);

            string palavra = adress.Substring(ADDRESSBITS - offSet_Size, offSet_Size);
            string conjunto = adress.Substring(ADDRESSBITS - offSet_Size - rows_Number, rows_Number);
            string rotulo = adress.Substring(0, setRows_Number);

            return new Address()
            {
                Offset = palavra,
                Set = Convert.ToInt32(conjunto, 2),
                Tag = rotulo
            };
        }

        #endregion
    }
}
