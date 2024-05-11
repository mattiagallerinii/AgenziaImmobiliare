using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenzia
{
    public class Appartamento
    {
        protected int id;
        protected string cognome;
        protected string nome;
        protected int superficie;
        protected int valoreMq;
        protected bool venduto;
        protected float provvigione;
        protected int costoImm;

        public Appartamento(int id, string cognome, string nome, int superficie, int valoreMq, bool venduto)
        {
            this.id = id;
            this.cognome = cognome;
            this.nome = nome;
            this.superficie = superficie;
            this.valoreMq = valoreMq;
            this.venduto = venduto;
            this.provvigione = 0;
            this.costoImm = superficie * valoreMq;
        }

        public virtual int CostoImmobile()
        {
            costoImm = superficie * valoreMq;
            return costoImm;
        }
        public virtual float Commissione()
        {
            if (costoImm <= 70000)
            {
                provvigione = (2 / 100) * costoImm;
            }
            else
            {
                provvigione = (4 / 100) * costoImm;
            }
            return provvigione;
        }

        public virtual bool Vendita()
        {
            if (venduto == false)
            {
                venduto = true;
            }
            this.Commissione();
            return venduto;
        }

        public int GetId()
        {
            return id;
        }
        public int SetId(int id)
        {
            this.id = id;
            return 0;
        }

        public int SetCognome(string cognome)
        {
            this.cognome = cognome;
            return 0;
        }

        public int SetNome(string nome)
        {
            this.nome = nome;
            return 0;
        }


        public virtual string ToString()
        {
            string str = this.id.ToString();
            str = str + ", " + this.cognome;
            str = str + ", " + this.nome;
            str = str + ", Appartamento";
            str = str + ", " + this.superficie.ToString();
            str = str + ", " + this.costoImm.ToString();
            return str;
        }
         
        
    }
}
