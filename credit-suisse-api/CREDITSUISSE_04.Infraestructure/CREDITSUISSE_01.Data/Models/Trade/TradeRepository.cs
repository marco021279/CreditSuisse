using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using CREDITSUISSE_03.Domain.Trade.Interfaces;
using CREDITSUISSE_03.Domain.Trade.Models;
using System;
using System.Text.RegularExpressions;

namespace CREDITSUISSE_05.Data.Models.Trade.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        public TradeRepository()
        {
        }
       
        private IList<TradeModel> listTrade = new List<TradeModel>();
        private DateTime LaunchDate;
        private int QtdRegisters;

        public static bool DateIdentify(string data)
        {
            Regex r = new Regex(@"(\d{2}\/\d{2}\/\d{4})");
            return r.Match(data).Success && data.Length == 10;
        }

        public async Task<IEnumerable<TradeModel>> GetAllCategorized()
        {
            string archive = @"C:\Projetos\Teste\trade.txt";

            if (File.Exists(archive))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(archive))
                    {
                        string line;
                        int qtdRegisters = 0;
                        
                        while ((line = sr.ReadLine()) != null)
                        {
                            if(DateIdentify(line))
                            {
                                var dateNormalized =  line.Substring(3,2) + "/" + line.Substring(0,2) + "/" + line.Substring(6,4);
                                this.LaunchDate = DateTime.Parse(dateNormalized);
                            }

                            if(int.TryParse(line, out this.QtdRegisters))
                            {
                                qtdRegisters = this.QtdRegisters;
                            }
                            else if(qtdRegisters > 0)
                            {
                                var explodedLine = line.Split(' ');
                                var model = new TradeModel();
                                var dateNormalized = explodedLine[2].Substring(3,2) + "/" + explodedLine[2].Substring(0,2) + "/" + explodedLine[2].Substring(6,4);
                                model.UpdateTrade(double.Parse(explodedLine[0]), explodedLine[1], DateTime.Parse(dateNormalized), "", this.LaunchDate, qtdRegisters);
                                listTrade.Add(model);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine(" O arquivo " + archive + "não foi localizaod !");
            }

            return await Task.FromResult<IEnumerable<TradeModel>>(listTrade);
        }
    }
}