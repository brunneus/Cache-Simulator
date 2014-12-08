using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoCache
{
    public enum WritePolicy
    {
        WriteThrough,
        WriteBack,
    }

    public class CacheMemory
    {
        #region Constructors

        public CacheMemory()
        {
            Sets = new List<Set>();
        }

        #endregion

        #region Attributes and Properties

        //Tamanho da linha
        private int RowSize { get; set; }

        //Número de linhas
        private int RowsNumber { get; set; }

        //Número de linhas por conjunto
        private int Associativity { get; set; }

        //Lista de conjuntos
        private List<Set> Sets { get; set; }
        
        //Politica de escrita
        private WritePolicy WritePolicy { get; set; }

        //Tempo de acesso
        private int AccessTime { get; set; }

        //Escritas na cache
        private int Writes { get; set; }

        //Leituras na cache
        private int Reads { get; set; }

        //Taxa de acerto em escritas
        private int WriteHits { get; set; }

        //Taxa de erro na em escritas
        private int WriteMiss { get; set; }

        //Taxa de erros em leituras
        private int ReadMiss { get; set; }

        //Taxa de acertos em leituras
        private int ReadHits { get; set; }

        #endregion

        #region Public Methods

        //Le endereço na memória cache
        public void ReadAddress(Address address)
        {
            //Verifica se o endereço requisitado está na cache
            if (this.IsInCache(address))
                this.ReadHits++;
            else
            {
                Set currentSet = this.GetSetByAdress(address);
                Block block = this.CreateBlock(address);

                //Caso o currentSet que seria o conjunto do endereço requisitado seja diferente de null, ou seja, existe o conjunto para o endereço requisitado,
                // é criado o bloco e adicionado no conjunto, caso este conjunto esteja cheio, é realizado a troca do bloco mais antigo dentro do conjutno.
                if (currentSet != null)
                {
                    if (currentSet.IsFull())
                        this.ReplaceLeastUsedBlock(currentSet, block);
                    else
                        currentSet.Blocks.Add(block);
                }

                //Caso o conjunto na memória cache não exista, é criado um novo conjunto apartir do endereço solicitado e também é criado o bloco e adicionado o mesmo ao conjunto
                else
                {
                    Set newSet = this.CreateSet(address);
                    newSet.Blocks.Add(block);

                    this.Sets.Add(newSet);
                }

                //Como o bloco do endereço requisitado não estava na cache, ocorre um miss e uma leitura na memória principal.
                this.ReadMiss++;
                MainMemory.Reads++;
            }

            this.Reads++;
        }

        //Escreve o endereço na memória cache
        public void WriteAddress(Address address)
        {
            //Recupera o conjunto do endereço desejado, se existir.
            Set currentSet = this.GetSetByAdress(address);

            
            if (currentSet != null)
            {
                //Recupera o bloco do endereço desejado, se existir.
                Block currentBlock = this.GetBlockByAdress(address);

                if (currentBlock != null)
                {
                    //Atualizado o endereço na cache, se a politica de escrita for WriteThrough, ele escreva na MP, caso contrário seta o DirtyBit do bloco com 1.
                    if (this.WritePolicy == WritePolicy.WriteThrough)
                        MainMemory.Writes++;
                    else
                        currentBlock.DirtyBit = 1;
                    
                    this.WriteHits++;
                }
                else
                {
                    //Caso o endereço desejado não esteja na cache, ele cria um novo bloco.
                    currentBlock = this.CreateBlock(address);
                    
                    if (this.WritePolicy == TrabalhoCache.WritePolicy.WriteThrough)
                        MainMemory.Writes++;
                    else
                        currentBlock.DirtyBit = 1;

                    //Troca o bloco mais antigo do conjunto, caso o mesmo esteja cheio
                    if (currentSet.IsFull())
                        this.ReplaceLeastUsedBlock(currentSet, currentBlock);
                    else
                        currentSet.Blocks.Add(currentBlock);

                    this.WriteMiss++;
                    MainMemory.Reads++;
                }
            }
            else
            {
                //Cria um novo conjunto e usa o endereço para criar um novo bloco que vai ser armazendo no novo conjunto
                Set newSet = this.CreateSet(address);
                newSet.Blocks.Add(this.CreateBlock(address));

                this.Sets.Add(newSet);

                this.WriteMiss++;
                MainMemory.Reads++;
            }

            this.Writes++;
        }

        //Cria a configuração da cache através dos parametros da tela inicial.
        public void SetCache(int rowSize, int rowsNumber, int setRowsNumber, WritePolicy writePolicy, int accessTime)
        {
            this.RowSize = rowSize;
            this.RowsNumber = rowsNumber;
            this.Associativity = setRowsNumber;
            this.WritePolicy = writePolicy;
            this.AccessTime = accessTime;
        }

        //Retorna uma string com todas as infomações de entrada e saida.
        public string CreateReport()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(string.Concat("--------------Parâmetros de entrada--------------"));
            builder.AppendLine(string.Concat("Tamanho linha: ", this.RowSize));
            builder.AppendLine(string.Concat("Número de linhas: ", this.RowsNumber, " bytes"));
            builder.AppendLine(string.Concat("Número de linhas por conjunto: ", this.Associativity));
            builder.AppendLine(string.Concat("Politica de escrita: ", this.WritePolicy));
            builder.AppendLine(string.Concat("Tempo de acesso cache: ", this.AccessTime));
            builder.AppendLine(string.Concat("Tempo acesso MP: ", MainMemory.AccessTime));
            builder.AppendLine(Environment.NewLine);

            builder.AppendLine(string.Concat("--------------Parâmetros de saida--------------"));
            builder.AppendLine(string.Concat("* Total de endereços no aquivo de entrada: ", this.Writes + this.Reads));
            builder.AppendLine(string.Concat("\tLeituras cache: ", this.Reads));
            builder.AppendLine(string.Concat("\tEscritas cache: ", this.Writes));
            builder.AppendLine(string.Concat("* Total de acessos à memória principal: ", MainMemory.Writes + MainMemory.Reads));
            builder.AppendLine(string.Concat("\tLeituras MP: ", MainMemory.Reads));
            builder.AppendLine(string.Concat("\tEscritas MP: ", MainMemory.Writes));
            builder.AppendLine(string.Concat("* Taxa de acerto"));
            builder.AppendLine(string.Concat("\tTaxa por leitura: ", this.GetReadHitRate(), "%", " (Hits: ", this.ReadHits, " / Miss: ", this.ReadMiss, ")"));
            builder.AppendLine(string.Concat("\tTaxa por escrita: ", this.GetWriteHitRate(), "%", " (Hits: ", this.WriteHits, " / Miss: ",this.WriteMiss, ")"));
            builder.AppendLine(string.Concat("\tTaxa global: ", this.GetGlobalHitRate(), "%", "(", this.ReadHits + this.WriteHits, ")"));
            builder.AppendLine(string.Concat("* Tempo médio de acesso: ", this.GetAgeraveAccessTime(), " ns"));

            return builder.ToString();
        }

        #endregion

        #region Private Methods

        //Cria um novo conjunto
        private Set CreateSet(Address address)
        {
            return new Set() { Associativity = this.Associativity, Number = address.Set };
        }

        //Cria um novo bloco
        private Block CreateBlock(Address endereco)
        {
            return new Block()
            {
                LRUControl = this.Associativity,
                OffSet = endereco.Offset,
                Tag = endereco.Tag
            };
        }

        //Retorna o bloco do endereço desejado, se existir.
        private Block GetBlockByAdress(Address endereco)
        {
            Set blockSet = this.GetSetByAdress(endereco);

            if (blockSet == null)
                return null;

            return blockSet.Blocks.FirstOrDefault(t => t.Tag.Equals(endereco.Tag));
        }

        //Retorna o conjunto do endereço desejado, se existir.
        private Set GetSetByAdress(Address endereco)
        {
            return this.Sets.FirstOrDefault(t => t.Number.Equals(endereco.Set));
        }

        //Substitui o bloco menos antigo no conjunto
        private void ReplaceLeastUsedBlock(Set set, Block block)
        {
            if (set == null || block == null)
                return;

            Block leastUsedBlock = set.Blocks.OrderBy(t => t.LRUControl).First();

            if (this.WritePolicy == TrabalhoCache.WritePolicy.WriteBack && leastUsedBlock.DirtyBit == 1)
                MainMemory.Writes++;

            set.Blocks.Remove(leastUsedBlock);
            set.Blocks.Add(block);
        }

        //Verifica se o endereço desejado está na cache.
        private bool IsInCache(Address endereco)
        {
            Set conjuntoAtual = Sets.FirstOrDefault(t => t.Number.Equals(endereco.Set));

            return (conjuntoAtual != null && conjuntoAtual.Blocks.Any(t => t.Tag.Equals(endereco.Tag)));
        }

        //Retorna o tempo médio de acesso.
        private string GetAgeraveAccessTime()
        
        {
            double percentualHit = (double)(this.ReadHits + this.WriteHits) / (this.Reads + this.Writes);

            double tm = percentualHit * this.AccessTime + (1 - percentualHit) * (MainMemory.AccessTime + this.AccessTime);
            string str = tm.ToString("R");

            return str.Truncate();
        }

        //Retorna a taxa de acerto de escrita
        private string GetWriteHitRate()
        {
            int hitRate = this.WriteHits * 100;
            double result = (double)hitRate / this.Writes;

            return result.ToString("R").Truncate();
        }

        //Retorna a taxa de acerto de leitura
        private string GetReadHitRate()
        {
            int hitRate = this.ReadHits * 100;
            double result = (double)hitRate / this.Reads;

            string strResult = result.ToString("R");

            return strResult.Truncate();
        }

        //Retorna a taxa de acerto global
        private string GetGlobalHitRate()
        {
            int total = this.Writes + this.Reads;
            int hits = (this.WriteHits + this.ReadHits) * 100;

            double result = (double)hits / total;

            string strResult = result.ToString("R");

            return strResult.Truncate();
        }

        #endregion
    }
}
