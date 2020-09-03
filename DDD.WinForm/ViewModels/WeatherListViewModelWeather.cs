using DDD.Domain.Entities;

namespace DDD.WinForm.ViewModels
{
    public sealed class WeatherListViewModelWeather
    {
        private WeatherEntity _entity;
        public WeatherListViewModelWeather(WeatherEntity entity)
        {
            _entity = entity;
        }

        public string AreaId => _entity.AreaID.DisplayValue;
        public string AreaName => _entity.AreaName.ToString();
        public string DataDate => _entity.DataDate.ToString();
        public string Condition => _entity.Condition.Displayvalue;
        public string Temperature => _entity.Temperature.DisplayValueWIthUnitSpace;
    }
}
