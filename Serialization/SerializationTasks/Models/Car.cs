using System.Runtime.Serialization;

namespace SerializationTasks.Models
{
    [Serializable]
    public class Car : ISerializable
    {
        public string Brand { get; set; }

        public int Year { get; set; }

        public Car(string brand, int year)
        {
            Brand = brand;
            Year = year;
        }

        public Car(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            try
            {
                Brand = info.GetString(nameof(Brand));
                Year = info.GetInt32(nameof(Year));
            }
            catch 
            {
                throw new ArgumentException("SerializationInfo not contain specified values.");
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Brand), Brand);
            info.AddValue(nameof(Year), Year);
        }
    }
}
