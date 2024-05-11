using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenzia
{
    public class Villa : Appartamento
    {
        int giardinoMq;
        int valoreMqGiardino;
        public Villa(int id, string cognome, string nome, int superficie, int valoreMq,
            bool venduto, int giardinoMq, int valoreMqGiardino):base(id, cognome, nome, superficie, valoreMq,venduto)
        {
            this.giardinoMq = giardinoMq;
            this.valoreMqGiardino = valoreMqGiardino;
            this.costoImm = this.costoImm + (this.giardinoMq * this.valoreMqGiardino);
        }

        public int SetGiardinoMq(int giardinoMq)
        {
            this.giardinoMq = giardinoMq;
            return 0;
        }
        public int SetValoreMqGiardino(int valoreMqGiardino)
        {
            this.valoreMqGiardino = valoreMqGiardino;
            return 0;
        }

        public int GetValoreMqGiardino()
        {
            return this.valoreMqGiardino;
        }
        public int GetGiardinoMq()
        {
            return this.giardinoMq;
        }

        
        public override int CostoImmobile()
        {
            costoImm = base.CostoImmobile() + (giardinoMq*valoreMqGiardino);
            return costoImm;
        }
        public override float Commissione()
        {
            provvigione = (5 / 100) * costoImm;
            return provvigione;
        }

        public override bool Vendita()
        {
            base.Vendita();
            this.Commissione();
            return venduto;
        }

        public override string ToString()
        {
            string str = this.id.ToString();
            str = str + ", " + this.cognome;
            str = str + ", " + this.nome;
            str = str + ", Villa";
            str = str + ", " + this.superficie.ToString();
            str = str + ", " + this.giardinoMq.ToString();
            str = str + ", " + this.costoImm.ToString();
            return str;
        }

    }
}
