
using DDD.Domain.ValueObjects;
using System;

namespace DDD.Domain.Entities
{
    public sealed class WeatherEntity
    {
        //完全コンストラクタパターン
        public WeatherEntity(int areaId,
                            DateTime dataDate,
                            int condition,
                            float temperature)
        {
            AreaID = areaId;
            DataDate = dataDate;
            Condition = new Condition(condition);
            Temperature = new Temperature(temperature);
        }

        public int AreaID { get;  }
        public DateTime DataDate { get; }
        public Condition Condition { get; }
        public Temperature Temperature { get; }

        public bool IsMousyo()
        {
            if(Condition.IsSunny())
            {
                if(Temperature.Value > 30)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsOK()
        {
            if (DataDate < DateTime.Now.AddMonths(-1))
            {
                if(Temperature.Value < 10)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
