namespace Claims.Submissions.Domain.Entities
{
    /// <summary>
    /// Domain entity representing a vehicle associated with an occurrence.
    /// </summary>
    public class Vehicle
    {
        public string Vin { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }

        public static Vehicle IdentifiedBy(string vin)
        {
            return new Vehicle
            {
                Vin = vin
            };
        }

        public Vehicle DescribedAs(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;

            return this;
        }
    }
}